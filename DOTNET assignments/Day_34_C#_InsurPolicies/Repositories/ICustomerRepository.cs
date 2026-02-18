using Day_34_C__InsurPolicies.Models;

namespace Day_34_C__InsurPolicies.Repositories
{
    public interface ICustomerRepository
    {
        // Task to save a new customer to the Koushik SQL database
        Task<Customer> AddCustomer(Customer customer);

        // Task to retrieve all customers, which will include their linked policies
        Task<IEnumerable<Customer>> GetAllCustomers();
    }
}