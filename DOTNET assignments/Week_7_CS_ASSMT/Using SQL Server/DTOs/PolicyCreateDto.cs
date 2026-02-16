namespace Day_32_C_.DTOs
{
    public class PolicyCreateDto
    {
        public string PolicyNumber { get; set; }
        public string Type { get; set; }
        public decimal PremiumAmount { get; set; }
        public int CustomerId { get; set; }
    }
}
