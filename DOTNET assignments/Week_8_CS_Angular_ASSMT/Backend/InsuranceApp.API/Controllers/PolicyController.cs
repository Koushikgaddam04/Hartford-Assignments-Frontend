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
public class PolicyController : ControllerBase
{
    private readonly IPolicyRepository _policyRepository;
    private readonly IMapper _mapper;

    public PolicyController(IPolicyRepository policyRepository, IMapper mapper)
    {
        _policyRepository = policyRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var policies = await _policyRepository.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<PolicyDto>>(policies));
    }

    [HttpGet("customer/{customerId}")]
    public async Task<IActionResult> GetByCustomer(int customerId)
    {
        var policies = await _policyRepository.GetPoliciesByCustomerIdAsync(customerId);
        return Ok(_mapper.Map<IEnumerable<PolicyDto>>(policies));
    }

    [HttpGet("agent/{agentId}")]
    [Authorize(Roles = "Admin,Agent")]
    public async Task<IActionResult> GetByAgent(int agentId)
    {
        var policies = await _policyRepository.GetPoliciesByAgentIdAsync(agentId);
        return Ok(_mapper.Map<IEnumerable<PolicyDto>>(policies));
    }

    [HttpPost]
    [Authorize(Roles = "Customer")]
    public async Task<IActionResult> CreatePolicy([FromBody] CreatePolicyDto dto)
    {
        var policy = _mapper.Map<Policy>(dto);
        policy.Status = "Pending"; // Always pending initially
        await _policyRepository.AddAsync(policy);
        
        return Ok(_mapper.Map<PolicyDto>(policy));
    }

    [HttpPut("{policyId}/status")]
    [Authorize(Roles = "Admin,Agent")]
    public async Task<IActionResult> UpdateStatus(int policyId, [FromBody] UpdatePolicyStatusDto dto)
    {
        var policy = await _policyRepository.GetByIdAsync(policyId);
        if (policy == null) return NotFound();

        policy.Status = dto.Status;
        await _policyRepository.UpdateAsync(policy);
        return Ok(new { message = $"Policy status updated to {dto.Status}" });
    }
}
