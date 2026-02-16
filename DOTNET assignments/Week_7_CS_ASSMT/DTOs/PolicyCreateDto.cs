namespace Week_7_CS_ASSMT.DTOs
{
    public class PolicyCreateDto
    {
        // We exclude 'Id' so it doesn't show up in Swagger's Request Body
        public string PolicyNumber { get; set; }
        public string Type { get; set; }
        public decimal PremiumAmount { get; set; }
        public int CustomerId { get; set; }
    }
}