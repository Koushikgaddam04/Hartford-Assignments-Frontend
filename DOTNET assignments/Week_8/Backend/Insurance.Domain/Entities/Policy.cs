namespace Insurance.Domain.Entities;

public class Policy
{
    public int Id { get; set; }
    public string PolicyNumber { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public decimal Premium { get; set; }

    // Statuses: "Pending", "Approved", "Rejected"
    public string Status { get; set; } = "Pending";

    public int UserId { get; set; } // The Customer who created it
    public User? User { get; set; }
}