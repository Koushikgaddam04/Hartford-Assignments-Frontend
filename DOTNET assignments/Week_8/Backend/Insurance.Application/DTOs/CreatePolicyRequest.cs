namespace Insurance.Application.DTOs;

public class CreatePolicyRequest
{
    public string PolicyNumber { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public decimal Premium { get; set; }
}