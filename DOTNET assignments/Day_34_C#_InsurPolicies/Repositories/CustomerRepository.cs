using Day_34_C__InsurPolicies.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_34_C__InsurPolicies.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly InsuranceContext _context;

        // Dependency Injection: Bringing the DB Context into the Repo
        public CustomerRepository(InsuranceContext context)
        {
            _context = context;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            // Includes the Policies list so the relationship is visible
            return await _context.Customers.Include(c => c.Policies).ToListAsync();
        }
    }
}