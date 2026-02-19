namespace Day_35_C__InsurancePoliciesFullstack.DTOs
{
    public class PolicyCreateDTO
    {
        public string PolicyNumber { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public decimal Premium { get; set; }
        public DateTime StartDate { get; set; }
        public int CustomerId { get; set; } // We only need the ID to link them
    }
}