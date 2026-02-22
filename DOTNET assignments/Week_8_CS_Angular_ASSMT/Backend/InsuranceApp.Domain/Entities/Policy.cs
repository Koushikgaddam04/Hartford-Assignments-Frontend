namespace InsuranceApp.Domain.Entities;

public class Policy
{
    public int Id { get; set; }
    public string PolicyNumber { get; set; } = string.Empty;
    public string PolicyType { get; set; } = string.Empty;
    public decimal PremiumAmount { get; set; }
    public string Status { get; set; } = "Pending"; // Pending, Accepted, Rejected
    
    // Foreign Key to Customer
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
}
