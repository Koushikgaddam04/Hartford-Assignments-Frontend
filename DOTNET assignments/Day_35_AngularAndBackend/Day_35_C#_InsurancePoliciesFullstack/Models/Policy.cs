using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Day_35_C__InsurancePoliciesFullstack.Models
{

    public class Policy
    {
        [Key] // Explicitly marking the Primary Key
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string PolicyNumber { get; set; } = string.Empty;

        [Required]
        public string Type { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")] // Specifying precision for money
        public decimal Premium { get; set; }

        public DateTime StartDate { get; set; }

        // Foreign Key Configuration
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")] // Explicitly linking the FK property to the navigation property
        public Customer? Customer { get; set; }
    }
}
