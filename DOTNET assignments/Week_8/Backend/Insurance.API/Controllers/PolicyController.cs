using Insurance.Application.DTOs;
using Insurance.Application.Interfaces;
using Insurance.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Insurance.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize] // Requires a valid JWT for any action
public class PolicyController : ControllerBase
{
    private readonly IPolicyRepository _policyRepo;

    public PolicyController(IPolicyRepository policyRepo)
    {
        _policyRepo = policyRepo;
    }

    // CUSTOMER: Create a policy
    [HttpPost]
    [Authorize(Roles = "Customer")]
    public async Task<IActionResult> Create(CreatePolicyRequest request)
    {
        var userId = int.Parse(User.FindFirst("UserId")?.Value!);

        var policy = new Policy
        {
            PolicyNumber = request.PolicyNumber,
            Type = request.Type,
            Premium = request.Premium,
            UserId = userId,
            Status = "Pending"
        };

        await _policyRepo.AddAsync(policy);
        return Ok(new { message = "Policy submitted for review." });
    }

    // AGENT: Approve or Reject
    [HttpPut("{id}/status")]
    [Authorize(Roles = "Agent")]
    public async Task<IActionResult> UpdateStatus(int id, [FromBody] string newStatus)
    {
        var policy = await _policyRepo.GetByIdAsync(id);
        if (policy == null) return NotFound();

        policy.Status = newStatus; // "Approved" or "Rejected"
        await _policyRepo.UpdateAsync(policy);
        return Ok(new { message = $"Policy {newStatus} successfully." });
    }

    // ADMIN: View All
    [HttpGet("all")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var policies = await _policyRepo.GetAllPoliciesAsync();
        return Ok(policies);
    }
}