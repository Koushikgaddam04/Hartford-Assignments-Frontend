namespace Insurance.Application.DTOs;

public class PolicyResponseDTO
{
    public int Id { get; set; }
    public string PolicyNumber { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public decimal Premium { get; set; }
    public string Status { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
}