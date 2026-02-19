using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Day_35_C__InsurancePoliciesFullstack.Models
{
    

    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [EmailAddress] // Validates format automatically
        public string Email { get; set; } = string.Empty;
        [JsonIgnore]
        public List<Policy> Policies { get; set; } = new();
    }
}
