using MoviesWebApp.DTOs;
using MoviesWebApp.Models;

namespace MoviesWebApp.Services
{
    public interface IMovieService
    {
        List<Movies> GetAll();
        Movies GetById(int id);
        Movies Add(MovieCreateDTO dto);
        bool Update(int id, MovieCreateDTO dto);
        bool Delete(int id);
    }
}
