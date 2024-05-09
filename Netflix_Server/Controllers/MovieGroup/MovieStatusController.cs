using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Netflix_Server.Models.MovieGroup;
using Netflix_Server.Repository.MovieGroup;

namespace Netflix_Server.Controllers.MovieGroup
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieStatusController : ControllerBase
    {
        private readonly MovieStatusRepository _MovieStatusRepository;

        public MovieStatusController(MovieStatusRepository movieStatusRepository)
        {
            _MovieStatusRepository = movieStatusRepository;
        }

        // GET: api/MovieStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieStatus>>> GetMovieStatus()
        {
            var movieStatuses = await _MovieStatusRepository.GetList();
            return Ok(movieStatuses);
        }

        // GET: api/MovieStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieStatus>> GetMovieStatus(int id)
        {
            var movieStatus = await _MovieStatusRepository.GetById(id);

            if (movieStatus == null)
            {
                return NotFound();
            }

            return movieStatus;
        }

        // PUT: api/MovieStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieStatus(int id, MovieStatus movieStatus)
        {
            if (id != movieStatus.Id)
            {
                return BadRequest();
            }

            try
            {
                 _MovieStatusRepository.Update(movieStatus);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _MovieStatusRepository.Exists(id))
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

        // POST: api/MovieStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovieStatus>> PostMovieStatus(MovieStatus movieStatus)
        {
            await _MovieStatusRepository.Create(movieStatus);

            return CreatedAtAction(nameof(GetMovieStatus), new { id = movieStatus.Id }, movieStatus);
        }

        // DELETE: api/MovieStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieStatus(int id)
        {
            var movieStatus = await _MovieStatusRepository.GetById(id);
            if (movieStatus == null)
            {
                return NotFound();
            }

            await _MovieStatusRepository.Delete(id);

            return NoContent();
        }
    }
}
