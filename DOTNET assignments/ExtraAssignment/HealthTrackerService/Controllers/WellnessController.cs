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
    public class WellnessController : ControllerBase
    {
        private readonly HealthDbContext _context;

        public WellnessController(HealthDbContext context)
        {
            _context = context;
        }

        private string CurrentUser => User.Identity?.Name ?? "Anonymous";

        [HttpGet("mood")]
        public async Task<ActionResult<IEnumerable<MoodLog>>> GetMoodLogs()
        {
            return await _context.MoodLogs
                .Where(m => m.Username == CurrentUser)
                .OrderByDescending(m => m.Date)
                .ToListAsync();
        }

        [HttpPost("mood")]
        public async Task<ActionResult<MoodLog>> PostMoodLog(MoodLog moodLog)
        {
            moodLog.Username = CurrentUser;
            _context.MoodLogs.Add(moodLog);
            await _context.SaveChangesAsync();
            return Ok(moodLog);
        }

        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary()
        {
            var today = DateTime.UtcNow.Date;
            
            var dailyCaloriesBurned = await _context.Activities
                .Where(a => a.Username == CurrentUser && a.Date >= today)
                .SumAsync(a => a.CaloriesBurned);

            var dailyCaloriesConsumed = await _context.Meals
                .Where(m => m.Username == CurrentUser && m.Date >= today)
                .SumAsync(m => m.Calories);

            var avgMood = await _context.MoodLogs
                .Where(m => m.Username == CurrentUser)
                .OrderByDescending(m => m.Date)
                .Take(7)
                .AverageAsync(m => (double?)m.Score) ?? 0;

            return Ok(new
            {
                Username = CurrentUser,
                CaloriesBurnedToday = dailyCaloriesBurned,
                CaloriesConsumedToday = dailyCaloriesConsumed,
                NetCalories = dailyCaloriesConsumed - dailyCaloriesBurned,
                AverageMoodLast7Logs = Math.Round(avgMood, 2)
            });
        }
    }
}
