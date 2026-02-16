using Day_32_C_.DTOs;
using Day_32_C_.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day_32_C_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsurancePoliciesController : ControllerBase
    {
        private readonly InsuranceContext _context;

        public InsurancePoliciesController(InsuranceContext context)
        {
            _context = context;
        }

        // GET: api/InsurancePolicies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InsurancePolicy>>> GetInsurancePolicies()
        {
            return await _context.InsurancePolicies.ToListAsync();
        }

        // GET: api/InsurancePolicies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InsurancePolicy>> GetInsurancePolicy(int id)
        {
            var insurancePolicy = await _context.InsurancePolicies.FindAsync(id);

            if (insurancePolicy == null)
            {
                return NotFound();
            }

            return insurancePolicy;
        }

        // PUT: api/InsurancePolicies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsurancePolicy(int id, InsurancePolicy insurancePolicy)
        {
            if (id != insurancePolicy.Id)
            {
                return BadRequest();
            }

            _context.Entry(insurancePolicy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsurancePolicyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/InsurancePolicies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InsurancePolicy>> PostInsurancePolicy(PolicyCreateDto policyDto)
        {
            var insurancePolicy = new InsurancePolicy
            {
                PolicyNumber = policyDto.PolicyNumber,
                Type = policyDto.Type,
                PremiumAmount = policyDto.PremiumAmount,
                CustomerId = policyDto.CustomerId
            };
            _context.InsurancePolicies.Add(insurancePolicy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInsurancePolicy", new { id = insurancePolicy.Id }, insurancePolicy);
        }

        // DELETE: api/InsurancePolicies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsurancePolicy(int id)
        {
            var insurancePolicy = await _context.InsurancePolicies.FindAsync(id);
            if (insurancePolicy == null)
            {
                return NotFound();
            }

            _context.InsurancePolicies.Remove(insurancePolicy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InsurancePolicyExists(int id)
        {
            return _context.InsurancePolicies.Any(e => e.Id == id);
        }
    }
}
