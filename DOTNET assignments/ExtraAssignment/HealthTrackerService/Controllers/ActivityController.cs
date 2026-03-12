using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthTrackerService.Data;
using HealthTrackerService.Models;
using System.Security.Claims;

namespace HealthTrackerService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly HealthDbContext _context;

        public ActivityController(HealthDbContext context)
        {
            _context = context;
        }

        private string CurrentUser => User.Identity?.Name ?? "Anonymous";

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivities()
        {
            return await _context.Activities
                .Where(a => a.Username == CurrentUser)
                .OrderByDescending(a => a.Date)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity == null || activity.Username != CurrentUser) return NotFound();
            return activity;
        }

        [HttpPost]
        public async Task<ActionResult<Activity>> PostActivity(Activity activity)
        {
            activity.Username = CurrentUser;
            _context.Activities.Add(activity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetActivity), new { id = activity.Id }, activity);
        }
    }
}
