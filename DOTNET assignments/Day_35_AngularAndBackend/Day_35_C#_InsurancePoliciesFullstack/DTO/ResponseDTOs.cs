using System;

namespace Day_35_C__InsurancePoliciesFullstack.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<PolicySummaryDTO> Policies { get; set; } = new List<PolicySummaryDTO>();
    }

    public class PolicyDTO
    {
        public int Id { get; set; }
        public string PolicyNumber { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public decimal Premium { get; set; }
        public DateTime StartDate { get; set; }
        public int CustomerId { get; set; }
        public CustomerSummaryDTO? Customer { get; set; }
    }

    public class PolicySummaryDTO
    {
        public int Id { get; set; }
        public string PolicyNumber { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public decimal Premium { get; set; }
        public DateTime StartDate { get; set; }
        public int CustomerId { get; set; }
    }

    public class CustomerSummaryDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
