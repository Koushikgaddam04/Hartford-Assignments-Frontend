namespace Insurance.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty; // Admin, Agent, Customer

    // Logic for Admin to Assign Agents
    public int? AssignedAgentId { get; set; }

    public List<Policy> Policies { get; set; } = new();
}