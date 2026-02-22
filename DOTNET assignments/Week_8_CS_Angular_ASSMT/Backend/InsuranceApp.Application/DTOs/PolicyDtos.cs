namespace InsuranceApp.Application.DTOs;

public class PolicyDto
{
    public int Id { get; set; }
    public string PolicyNumber { get; set; } = string.Empty;
    public string PolicyType { get; set; } = string.Empty;
    public decimal PremiumAmount { get; set; }
    public string Status { get; set; } = string.Empty;
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty; // Useful for UI
}

public class CreatePolicyDto
{
    public string PolicyNumber { get; set; } = string.Empty;
    public string PolicyType { get; set; } = string.Empty;
    public decimal PremiumAmount { get; set; }
    public int CustomerId { get; set; }
}

public class UpdatePolicyStatusDto
{
    public string Status { get; set; } = string.Empty; // "Accepted" or "Rejected"
}
