using AutoMapper;
using InsuranceApp.Application.DTOs;
using InsuranceApp.Application.Interfaces;
using InsuranceApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IConfiguration _config;

    public AuthController(IUserRepository userRepository, ICustomerRepository customerRepository, IConfiguration config)
    {
        _userRepository = userRepository;
        _customerRepository = customerRepository;
        _config = config;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        if (await _userRepository.GetByUsernameAsync(dto.Username) != null)
            return BadRequest("Username already exists.");

        var user = new User
        {
            Username = dto.Username,
            PasswordHash = dto.Password, // Simple plain text for mock/learning purposes
            Role = dto.Role
        };

        await _userRepository.AddAsync(user);

        // Auto-create a linked Customer profile for new customers
        if (dto.Role == "Customer")
        {
            var customerProfile = new Customer
            {
                FirstName = dto.Username,
                LastName = "User",
                Email = $"{dto.Username}@insuranceapp.local",
                UserId = user.Id
            };
            await _customerRepository.AddAsync(customerProfile);
        }

        return Ok(new { message = "User registered successfully" });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var user = await _userRepository.GetByUsernameAsync(dto.Username);
        
        // Match mock plain text password
        if (user == null || user.PasswordHash != dto.Password) 
            return Unauthorized("Invalid credentials.");

        // CAPTCHA validation mocked
        if (string.IsNullOrEmpty(dto.Captcha))
            return BadRequest("CAPTCHA is required.");

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_config["JwtSettings:Key"] ?? "FallbackSecretKeyThatIsLongEnoughToWork!@#");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            Issuer = _config["JwtSettings:Issuer"],
            Audience = _config["JwtSettings:Audience"],
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return Ok(new AuthResponseDto
        {
            Token = tokenHandler.WriteToken(token),
            Role = user.Role,
            Username = user.Username,
            UserId = user.Id
        });
    }
}
