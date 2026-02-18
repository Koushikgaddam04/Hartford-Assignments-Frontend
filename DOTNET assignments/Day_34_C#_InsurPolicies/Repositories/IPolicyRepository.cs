using Day_34_C__InsurPolicies.Models;

namespace Day_34_C__InsurPolicies.Repositories
{
    public interface IPolicyRepository
    {
        Task<InsurancePolicy> AddPolicy(InsurancePolicy policy);
    }
}