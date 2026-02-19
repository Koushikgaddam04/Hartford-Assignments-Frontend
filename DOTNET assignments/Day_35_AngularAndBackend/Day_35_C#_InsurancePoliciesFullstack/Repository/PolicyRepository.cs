using Day_35_C__InsurancePoliciesFullstack.Data;
using Day_35_C__InsurancePoliciesFullstack.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_35_C__InsurancePoliciesFullstack.Repositories
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly InsuranceDbContext _context;

        public PolicyRepository(InsuranceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Policy>> GetAllPoliciesAsync()
        {
            // We use .Include to bring back the Customer data with the Policy
            return await _context.Policies.Include(p => p.Customer).ToListAsync();
        }

        public async Task AddPolicyAsync(Policy policy)
        {
            await _context.Policies.AddAsync(policy);
            await _context.SaveChangesAsync(); // This saves to SQL Server
        }
    }
}