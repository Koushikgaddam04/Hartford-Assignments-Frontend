using AutoMapper;
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
        private readonly IMapper _mapper;

        public PoliciesController(IPolicyRepository policyRepo, IMapper mapper)
        {
            _policyRepo = policyRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PolicyDTO>>> GetPolicies()
        {
            // FIX: Changed _repository to _policyRepo
            var policies = await _policyRepo.GetAllPoliciesAsync();
            var policyDtos = _mapper.Map<IEnumerable<PolicyDTO>>(policies);
            return Ok(policyDtos);
        }

        [HttpPost]
        public async Task<ActionResult<Policy>> CreatePolicy(PolicyCreateDTO policyDto)
        {
            var policy = _mapper.Map<Policy>(policyDto);

            await _policyRepo.AddPolicyAsync(policy);
            return Ok(policy);
        }
    }
}