using Day_35_C__InsurancePoliciesFullstack.DTOs;
using Day_35_C__InsurancePoliciesFullstack.Models;
using Day_35_C__InsurancePoliciesFullstack.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Day_35_C__InsurancePoliciesFullstack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        private readonly IPolicyRepository _policyRepo;

        public PoliciesController(IPolicyRepository policyRepo)
        {
            _policyRepo = policyRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Policy>>> GetPolicies()
        {
            // FIX: Changed _repository to _policyRepo
            var policies = await _policyRepo.GetAllPoliciesAsync();
            return Ok(policies);
        }

        [HttpPost]
        public async Task<ActionResult<Policy>> CreatePolicy(PolicyCreateDTO policyDto)
        {
            var policy = new Policy
            {
                PolicyNumber = policyDto.PolicyNumber,
                Type = policyDto.Type,
                Premium = policyDto.Premium,
                StartDate = policyDto.StartDate,
                CustomerId = policyDto.CustomerId
            };

            await _policyRepo.AddPolicyAsync(policy);
            return Ok(policy);
        }
    }
}