using System.ComponentModel.DataAnnotations;

namespace GoalService.Models
{
    public class Goal
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Title { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public int TargetValue { get; set; }
        public int CurrentValue { get; set; }
        public string Unit { get; set; } = string.Empty; // kg, km, steps, etc.
        public DateTime TargetDate { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
