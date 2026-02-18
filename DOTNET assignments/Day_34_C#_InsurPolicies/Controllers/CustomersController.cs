using Day_34_C__InsurPolicies.DTOs;
using Day_34_C__InsurPolicies.Models;
using Day_34_C__InsurPolicies.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Day_34_C__InsurPolicies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _repo;

        public CustomersController(ICustomerRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(CustomerCreateDto dto)
        {
            // Map DTO to the real Model
            var customer = new Customer
            {
                Name = dto.Name,
                Email = dto.Email
            };

            // Save using Repository
            var result = await _repo.AddCustomer(customer);

            // Returns 201 Created with the new ID from SQL Server
            return CreatedAtAction(nameof(PostCustomer), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _repo.GetAllCustomers();
            return Ok(customers);
        }
    }
}