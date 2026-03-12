using Insurance.Domain.Entities;

namespace Insurance.Application.Interfaces;

public interface IPolicyRepository
{
    Task<IEnumerable<Policy>> GetAllPoliciesAsync();
    Task<Policy> GetByIdAsync(int id);
    Task AddAsync(Policy policy);
    Task UpdateAsync(Policy policy); // For Agents to Approve/Reject
}