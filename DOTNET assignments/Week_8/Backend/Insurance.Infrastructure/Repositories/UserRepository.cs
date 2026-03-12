using Insurance.Application.Interfaces;
using Insurance.Domain.Entities;
using Insurance.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context) => _context = context;

    public async Task<User?> GetUserByEmailAsync(string email) =>
        await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

    public async Task RegisterUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    // This satisfies the GetPendingCustomersAsync call from your Controller
    public async Task<List<User>> GetPendingCustomersAsync()
    {
        return await _context.Users
            .Where(u => u.Role == "Customer" && u.AssignedAgentId == null)
            .ToListAsync();
    }

    // Implementation for the Admin dropdown
    public async Task<List<User>> GetAgentsAsync()
    {
        return await _context.Users
            .Where(u => u.Role == "Agent")
            .ToListAsync();
    }

    // Unified Assign logic
    public async Task AssignAgentAsync(int customerId, int agentId)
    {
        var customer = await _context.Users.FindAsync(customerId);
        if (customer != null)
        {
            customer.AssignedAgentId = agentId;
            await _context.SaveChangesAsync();
        }
    }

    // Kept this as per your previous logic in case you use the boolean toggle elsewhere
    public async Task<IEnumerable<User>> GetCustomersByAgentStatusAsync(bool isAssigned)
    {
        return await _context.Users
            .Where(u => u.Role == "Customer" && (isAssigned ? u.AssignedAgentId != null : u.AssignedAgentId == null))
            .ToListAsync();
    }
}