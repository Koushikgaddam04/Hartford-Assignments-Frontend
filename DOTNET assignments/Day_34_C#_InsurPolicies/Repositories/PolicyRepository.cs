using Day_34_C__InsurPolicies.Models;

namespace Day_34_C__InsurPolicies.Repositories
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly InsuranceContext _context;
        public PolicyRepository(InsuranceContext context) { _context = context; }

        public async Task<InsurancePolicy> AddPolicy(InsurancePolicy policy)
        {
            _context.InsurancePolicies.Add(policy);
            await _context.SaveChangesAsync();
            return policy;
        }
    }
}