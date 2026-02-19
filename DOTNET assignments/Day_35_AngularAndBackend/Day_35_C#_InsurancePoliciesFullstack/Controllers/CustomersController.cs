using Day_35_C__InsurancePoliciesFullstack.DTOs;
using Day_35_C__InsurancePoliciesFullstack.Models;
using Day_35_C__InsurancePoliciesFullstack.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Day_35_C__InsurancePoliciesFullstack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        // Injecting the Customer Repository
        public CustomersController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _repository.GetAllCustomersAsync();
            return Ok(customers);
        }

        // GET: api/customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _repository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // POST: api/customers
        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(CustomerCreateDTO customerDto)
        {
            var customer = new Customer
            {
                Name = customerDto.Name,
                Email = customerDto.Email
            };

            await _repository.AddCustomerAsync(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }
    }
}