using Insurance.Application.DTOs;
using Insurance.Application.Interfaces;
using Insurance.Domain.Entities;
using Insurance.Infrastructure.Authentication;
using Insurance.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepo;
    private readonly JwtService _jwtService;
    public AuthController(IUserRepository userRepo, JwtService jwtService)
    {
        _userRepo = userRepo;
        _jwtService = jwtService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        // 1. Check if user already exists
        var existingUser = await _userRepo.GetUserByEmailAsync(request.Email);
        if (existingUser != null)
        {
            return BadRequest(new { message = "Email is already registered." });
        }
        // Simple password hashing (In production, use BCrypt or Identity)
        var user = new User
        {
            FullName = request.FullName,
            Email = request.Email,
            PasswordHash = request.Password, // Normally hashed!
            Role = request.Role
        };

        await _userRepo.RegisterUserAsync(user);
        return Ok(new { message = "Registration successful" });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        // 1. Verify CAPTCHA
        if (request.UserCaptcha != request.ActualCaptcha)
        {
            return BadRequest("Invalid CAPTCHA code.");
        }

        // 2. Find User
        var user = await _userRepo.GetUserByEmailAsync(request.Email);
        if (user == null || user.PasswordHash != request.Password)
        {
            return Unauthorized("Invalid credentials.");
        }

        // 3. Generate JWT
        var token = _jwtService.GenerateToken(user);

        // 4. Return Token and User Info
        return Ok(new
        {
            Token = token,
            User = new { user.FullName, user.Email, user.Role }
        });
    }

    [HttpGet("customers/pending")]
    [Authorize(Roles = "Admin")] // Ensure your token actually has the 'Admin' role
    public async Task<IActionResult> GetPendingCustomers()
    {
        var customers = await _userRepo.GetPendingCustomersAsync();
        return Ok(customers);
    }
}