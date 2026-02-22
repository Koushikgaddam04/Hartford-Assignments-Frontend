using InsuranceApp.Application.Interfaces;
using InsuranceApp.Domain.Entities;
using InsuranceApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceApp.Infrastructure.Repositories;

public class PolicyRepository : Repository<Policy>, IPolicyRepository
{
    public PolicyRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<Policy>> GetPoliciesByCustomerIdAsync(int customerId)
    {
        return await _dbSet
            .Include(p => p.Customer) // Include customer details for DTO mapping
            .Where(p => p.CustomerId == customerId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Policy>> GetPoliciesByAgentIdAsync(int agentId)
    {
        // Get policies where the customer's agent is the specified agent
        return await _dbSet
            .Include(p => p.Customer)
            .Where(p => p.Customer != null && p.Customer.AgentId == agentId)
            .ToListAsync();
    }
}
