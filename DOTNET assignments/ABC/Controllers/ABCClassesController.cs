using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ABC.Models;

namespace ABC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ABCClassesController : ControllerBase
    {
        private readonly ABCContext _context;

        public ABCClassesController(ABCContext context)
        {
            _context = context;
        }

        // GET: api/ABCClasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ABCClass>>> GetABCClasses()
        {
            return await _context.ABCClasses.ToListAsync();
        }

        // GET: api/ABCClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ABCClass>> GetABCClass(int id)
        {
            var aBCClass = await _context.ABCClasses.FindAsync(id);

            if (aBCClass == null)
            {
                return NotFound();
            }

            return aBCClass;
        }

        // PUT: api/ABCClasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutABCClass(int id, ABCClass aBCClass)
        {
            if (id != aBCClass.Id)
            {
                return BadRequest();
            }

            _context.Entry(aBCClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ABCClassExists(id))
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

        // POST: api/ABCClasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ABCClass>> PostABCClass(ABCClass aBCClass)
        {
            _context.ABCClasses.Add(aBCClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetABCClass", new { id = aBCClass.Id }, aBCClass);
        }

        // DELETE: api/ABCClasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteABCClass(int id)
        {
            var aBCClass = await _context.ABCClasses.FindAsync(id);
            if (aBCClass == null)
            {
                return NotFound();
            }

            _context.ABCClasses.Remove(aBCClass);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ABCClassExists(int id)
        {
            return _context.ABCClasses.Any(e => e.Id == id);
        }
    }
}
