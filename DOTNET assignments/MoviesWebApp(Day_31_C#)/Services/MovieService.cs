using MoviesWebApp.DTOs;
using MoviesWebApp.Models;

namespace MoviesWebApp.Services
{
    public class MovieService : IMovieService
    {
        private static List<Movies> _movieList = new List<Movies> {
        new Movies { MovieId = 1, MovieName = "Inception", Genre = "Sci-Fi", Rating = 8.8m }
    };

        public List<Movies> GetAll() => _movieList;

        public Movies GetById(int id) => _movieList.FirstOrDefault(m => m.MovieId == id);

        public Movies Add(MovieCreateDTO dto)
        {
            var newMovie = new Movies
            {
                MovieId = _movieList.Max(m => m.MovieId) + 1,
                MovieName = dto.MovieName,
                Genre = dto.Genre,
                Rating = dto.Rating
            };
            _movieList.Add(newMovie);
            return newMovie;
        }

        public bool Update(int id, MovieCreateDTO dto)
        {
            var movie = GetById(id);
            if (movie == null) return false;

            movie.MovieName = dto.MovieName;
            movie.Genre = dto.Genre;
            movie.Rating = dto.Rating;
            return true;
        }

        public bool Delete(int id)
        {
            var movie = GetById(id);
            if (movie == null) return false;
            _movieList.Remove(movie);
            return true;
        }
    }
}
