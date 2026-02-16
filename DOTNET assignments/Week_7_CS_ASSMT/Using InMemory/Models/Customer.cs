using System.ComponentModel.DataAnnotations;

namespace Week_7_CS_ASSMT.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public List<InsurancePolicy>? Policies { get; set; }
    }
}