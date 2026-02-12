namespace MoviesWebApp.DTOs
{
    public class MovieCreateDTO
    {
        public string MovieName { get; set; }
        public string Genre { get; set; }
        public decimal Rating { get; set; }
    }

    public class MovieReadDTO
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Genre { get; set; }
    }
}
