using Day_33_C__JWT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Day_33_C__JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtSettings _jwtsettings;

        public AuthController(IOptions<JwtSettings> jwtOptions)
        {
            _jwtsettings = jwtOptions.Value;
        }

        [HttpPost("token")]
        public IActionResult GenerateToken()
        {
            try
            {
                // Basic check to ensure settings are loaded
                if (string.IsNullOrEmpty(_jwtsettings.SecretKey))
                {
                    return StatusCode(500, "JWT Secret Key is missing in configuration.");
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, "testuser"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtsettings.SecretKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _jwtsettings.Issuer,
                    audience: _jwtsettings.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(_jwtsettings.ExpiryMinutes),
                    signingCredentials: creds
                );

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
            catch (Exception ex)
            {
                // Returns a 500 error with the specific message (helpful for debugging)
                return StatusCode(500, $"Internal server error during token generation: {ex.Message}");
            }
        }

        [Microsoft.AspNetCore.Authorization.Authorize]
        [HttpGet("test-auth")]
        public IActionResult TestAuth()
        {
            try
            {
                return Ok("Success! Your token is valid.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}