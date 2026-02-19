using Day_35_C__InsurancePoliciesFullstack.Models;

namespace Day_35_C__InsurancePoliciesFullstack.Repositories
{
    public interface IPolicyRepository
    {
        Task<IEnumerable<Policy>> GetAllPoliciesAsync();
        Task AddPolicyAsync(Policy policy);
    }
}