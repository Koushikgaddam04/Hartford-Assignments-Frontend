using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoalService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MotivationController : ControllerBase
    {
        private static readonly string[] Quotes = new[]
        {
            "The only limit to our realization of tomorrow is our doubts of today.",
            "Quality is not an act, it is a habit.",
            "Health is the greatest gift, contentment the greatest wealth, faithfulness the best relationship.",
            "The secret of getting ahead is getting started.",
            "Well begun is half done.",
            "Keep your eyes on the stars, and your feet on the ground.",
            "Don't watch the clock; do what it does. Keep going."
        };

        [HttpGet("quote")]
        public IActionResult GetRandomQuote()
        {
            var random = new Random();
            var quote = Quotes[random.Next(Quotes.Length)];
            return Ok(new { Quote = quote, User = User.Identity?.Name });
        }
    }
}
