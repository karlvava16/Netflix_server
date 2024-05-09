using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Netflix_Server.IRepository;
using Netflix_Server.Models.MovieGroup;
using Netflix_Server.Repository;

namespace Netflix_Server.Controllers.MovieGroup
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IRepository<Movie> _movieRepository;

        public MoviesController(IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return await _movieRepository.GetList();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _movieRepository.GetById(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _movieRepository.Update(movie);

            try
            {
                await _movieRepository.Save();
            }
            catch
            {
                if (!await _movieRepository.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movies
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            await _movieRepository.Create(movie);

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _movieRepository.Delete(id);

            return NoContent();
        }
    }
}
