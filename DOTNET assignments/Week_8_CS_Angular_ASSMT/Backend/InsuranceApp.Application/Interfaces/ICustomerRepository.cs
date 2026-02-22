using InsuranceApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceApp.Application.Interfaces;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<Customer?> GetByUserIdAsync(int userId);
    Task<IEnumerable<Customer>> GetCustomersByAgentIdAsync(int agentId);
}
