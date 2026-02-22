using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace InsuranceApp.Domain.Entities;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    
    // Optional: An Agent assigned to this customer
    public int? AgentId { get; set; }
    public User? Agent { get; set; }

    // Link to the user authentication account
    public int? UserId { get; set; }
    public User? User { get; set; }

    // Crucial Fix: Prevent object cycle during serialization
    [JsonIgnore]
    public ICollection<Policy> Policies { get; set; } = new List<Policy>();
}
