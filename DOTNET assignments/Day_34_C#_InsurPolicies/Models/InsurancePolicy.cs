using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day_34_C__InsurPolicies.Models
{
    public class InsurancePolicy
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PolicyNumber { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PremiumAmount { get; set; }

        // Foreign Key Linking to Customer
        public int CustomerId { get; set; }

        // Navigation property to the Parent
        public Customer? Customer { get; set; }
    }
}