namespace Insurance.Application.DTOs;

public class LoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string UserCaptcha { get; set; } = string.Empty; // The text user typed
    public string ActualCaptcha { get; set; } = string.Empty; // The hidden "correct" text
}