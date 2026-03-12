using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthTrackerService.Data;
using HealthTrackerService.Models;

namespace HealthTrackerService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DietController : ControllerBase
    {
        private readonly HealthDbContext _context;

        public DietController(HealthDbContext context)
        {
            _context = context;
        }

        private string CurrentUser => User.Identity?.Name ?? "Anonymous";

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meal>>> GetMeals()
        {
            return await _context.Meals
                .Where(m => m.Username == CurrentUser)
                .OrderByDescending(m => m.Date)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Meal>> PostMeal(Meal meal)
        {
            meal.Username = CurrentUser;
            _context.Meals.Add(meal);
            await _context.SaveChangesAsync();
            return Ok(meal);
        }
    }
}
