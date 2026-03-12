using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GoalService.Models;

namespace GoalService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class GoalsController : ControllerBase
    {
        private static readonly List<Goal> _goals = new List<Goal>();
        private string CurrentUser => User.Identity?.Name ?? "Anonymous";

        [HttpGet]
        public ActionResult<IEnumerable<Goal>> GetGoals()
        {
            return Ok(_goals.Where(g => g.Username == CurrentUser));
        }

        [HttpPost]
        public ActionResult<Goal> CreateGoal(Goal goal)
        {
            goal.Id = _goals.Count + 1;
            goal.Username = CurrentUser;
            goal.CreatedAt = DateTime.UtcNow;
            _goals.Add(goal);
            return Ok(goal);
        }

        [HttpPut("{id}/progress")]
        public IActionResult UpdateProgress(int id, [FromBody] int newValue)
        {
            var goal = _goals.FirstOrDefault(g => g.Id == id && g.Username == CurrentUser);
            if (goal == null) return NotFound();

            goal.CurrentValue = newValue;
            if (goal.CurrentValue >= goal.TargetValue)
            {
                goal.IsCompleted = true;
            }

            return Ok(goal);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGoal(int id)
        {
            var goal = _goals.FirstOrDefault(g => g.Id == id && g.Username == CurrentUser);
            if (goal == null) return NotFound();

            _goals.Remove(goal);
            return NoContent();
        }
    }
}
