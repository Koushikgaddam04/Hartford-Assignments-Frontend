using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week_7_CS_ASSMT.DTOs;
using Week_7_CS_ASSMT.Models;

namespace Week_7_CS_ASSMT.Controllers
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
        public async Task<ActionResult<InsurancePolicy>> PostInsurancePolicy(PolicyCreateDto insuranceDto)
        {
            var insurancePolicy = new InsurancePolicy
            {
                PolicyNumber = insuranceDto.PolicyNumber,
                Type = insuranceDto.Type,
                PremiumAmount = insuranceDto.PremiumAmount,
                CustomerId = insuranceDto.CustomerId
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
