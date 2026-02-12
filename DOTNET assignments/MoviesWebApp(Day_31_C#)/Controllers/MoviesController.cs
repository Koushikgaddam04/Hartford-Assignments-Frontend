using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesWebApp.DTOs;
using MoviesWebApp.Models;
using MoviesWebApp.Services;

namespace MoviesWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _service;

        // The service is injected here
        public MoviesController(IMovieService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var movie = _service.GetById(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpPost]
        public IActionResult Create(MovieCreateDTO dto)
        {
            var movie = _service.Add(dto);
            return CreatedAtAction(nameof(GetById), new { id = movie.MovieId }, movie);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var deleted = _service.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

    }
}
