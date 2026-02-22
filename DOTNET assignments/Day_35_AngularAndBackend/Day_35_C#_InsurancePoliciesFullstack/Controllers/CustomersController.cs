using AutoMapper;
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
        private readonly IMapper _mapper;

        // Injecting the Customer Repository
        public CustomersController(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetCustomers()
        {
            var customers = await _repository.GetAllCustomersAsync();
            var customerDtos = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
            return Ok(customerDtos);
        }

        // GET: api/customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomer(int id)
        {
            var customer = await _repository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            var customerDto = _mapper.Map<CustomerDTO>(customer);
            return Ok(customerDto);
        }

        // POST: api/customers
        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(CustomerCreateDTO customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);

            await _repository.AddCustomerAsync(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }
    }
}