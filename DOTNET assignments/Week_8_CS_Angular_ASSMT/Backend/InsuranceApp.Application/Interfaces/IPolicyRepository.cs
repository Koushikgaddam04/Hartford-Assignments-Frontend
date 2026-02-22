using InsuranceApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceApp.Application.Interfaces;

public interface IPolicyRepository : IRepository<Policy>
{
    Task<IEnumerable<Policy>> GetPoliciesByCustomerIdAsync(int customerId);
    Task<IEnumerable<Policy>> GetPoliciesByAgentIdAsync(int agentId); // Since Agent is assigned to Customer
}
