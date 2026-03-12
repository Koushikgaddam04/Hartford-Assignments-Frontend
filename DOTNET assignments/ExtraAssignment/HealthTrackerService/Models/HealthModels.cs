using System.ComponentModel.DataAnnotations;

namespace HealthTrackerService.Models
{
    public class Activity
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Type { get; set; } = null!; // Running, Walking, Yoga, etc.
        public int DurationMinutes { get; set; }
        public int CaloriesBurned { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }

    public class Meal
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;
        public int Calories { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Fat { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }

    public class MoodLog
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public int Score { get; set; } // 1-10
        public string? Note { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
