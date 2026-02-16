using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Day_32_C_.Models
{
    public class InsurancePolicy
    {
        public int Id { get; set; }
        [Required]
        public string PolicyNumber { get; set; }
        public string Type { get; set; } // e.g., "Health", "Auto"
        public decimal PremiumAmount { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [JsonIgnore]
        public Customer? Customer { get; set; }
    }
}
