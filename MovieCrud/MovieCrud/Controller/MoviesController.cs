using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieCrud.Entity;
using MovieCrud.Models;

namespace MovieCrud.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IRepository<Movie> _repository;

        public MoviesController(IRepository<Movie> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movies = await _repository.ReadAllAsync();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movie = await _repository.ReadAsync(id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movie movie)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _repository.CreateAsync(movie);
            return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Movie movie)
        {
            if (id <= 0) return BadRequest("Invalid ID");
            movie.Id = id;
            await _repository.UpdateAsync(movie);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
