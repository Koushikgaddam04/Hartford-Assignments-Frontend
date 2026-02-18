using Day_34_C__InsurPolicies.DTOs;
using Day_34_C__InsurPolicies.Models;
using Day_34_C__InsurPolicies.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Day_34_C__InsurPolicies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InsurancePoliciesController : ControllerBase
    {
        private readonly IPolicyRepository _repo;

        public InsurancePoliciesController(IPolicyRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult<InsurancePolicy>> PostPolicy(PolicyCreateDto dto)
        {
            // Mapping the DTO to the actual Model
            var policy = new InsurancePolicy
            {
                PolicyNumber = dto.PolicyNumber,
                Type = dto.Type,
                PremiumAmount = dto.PremiumAmount,
                CustomerId = dto.CustomerId
            };

            var result = await _repo.AddPolicy(policy);

            // Returns 201 Created and the full object with the generated ID
            return CreatedAtAction(nameof(PostPolicy), new { id = result.Id }, result);
        }
    }
}