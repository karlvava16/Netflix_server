using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Netflix_Server.IRepositorys;
using Netflix_Server.Models.MovieGroup;
using Netflix_Server.Repository;

namespace Netflix_Server.Controllers.MovieGroup
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieImagesController : ControllerBase
    {
        private readonly IRepository<MovieImage> _movieImageRepository;

        public MovieImagesController(IRepository<MovieImage> movieImageRepository)
        {
            _movieImageRepository = movieImageRepository;
        }

        // GET: api/MovieImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieImage>>> GetMovieImages()
        {
            return await _movieImageRepository.GetList();
        }

        // GET: api/MovieImages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieImage>> GetMovieImage(int id)
        {
            var movieImage = await _movieImageRepository.GetById(id);

            if (movieImage == null)
            {
                return NotFound();
            }

            return movieImage;
        }

        // PUT: api/MovieImages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieImage(int id, MovieImage movieImage)
        {
            if (id != movieImage.Id)
            {
                return BadRequest();
            }

            _movieImageRepository.Update(movieImage);

            try
            {
                await _movieImageRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _movieImageRepository.Exists(id))
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

        // POST: api/MovieImages
        [HttpPost]
        public async Task<ActionResult<MovieImage>> PostMovieImage(MovieImage movieImage)
        {
            await _movieImageRepository.Create(movieImage);

            return CreatedAtAction("GetMovieImage", new { id = movieImage.Id }, movieImage);
        }

        // DELETE: api/MovieImages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieImage(int id)
        {
            await _movieImageRepository.Delete(id);

            return NoContent();
        }
    }
}
