using AutoMapper;
using InsuranceApp.Application.DTOs;
using InsuranceApp.Application.Interfaces;
using InsuranceApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceApp.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var customers = await _customerRepository.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<CustomerDto>>(customers));
    }

    [HttpGet("agent/{agentId}")]
    [Authorize(Roles = "Admin,Agent")]
    public async Task<IActionResult> GetByAgent(int agentId)
    {
        var customers = await _customerRepository.GetCustomersByAgentIdAsync(agentId);
        return Ok(_mapper.Map<IEnumerable<CustomerDto>>(customers));
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetProfile(int userId)
    {
        var customer = await _customerRepository.GetByUserIdAsync(userId);
        if (customer == null) return NotFound("Profile not found");
        return Ok(_mapper.Map<CustomerDto>(customer));
    }

    [HttpPost]
    public async Task<IActionResult> CreateProfile([FromBody] CreateCustomerDto dto)
    {
        var customer = _mapper.Map<Customer>(dto);
        await _customerRepository.AddAsync(customer);
        return Ok(_mapper.Map<CustomerDto>(customer));
    }

    [HttpPut("{customerId}/assign-agent/{agentId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AssignAgent(int customerId, int agentId)
    {
        var customer = await _customerRepository.GetByIdAsync(customerId);
        if (customer == null) return NotFound();

        customer.AgentId = agentId;
        await _customerRepository.UpdateAsync(customer);
        return Ok(new { message = "Agent assigned successfully." });
    }
}
