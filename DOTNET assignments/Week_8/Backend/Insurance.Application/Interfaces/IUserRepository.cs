using Insurance.Domain.Entities;

namespace Insurance.Application.Interfaces;

public interface IUserRepository
{
    Task RegisterUserAsync(User user);
    Task<User?> GetUserByEmailAsync(string email);

    // ADD THIS LINE
    Task<List<User>> GetPendingCustomersAsync();

    // You will also need these for the Admin Dashboard to work fully
    Task<List<User>> GetAgentsAsync();
    Task AssignAgentAsync(int customerId, int agentId);
}