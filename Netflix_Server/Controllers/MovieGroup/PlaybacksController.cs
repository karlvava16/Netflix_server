using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Netflix_Server.IRepositorys;
using Netflix_Server.Models.MovieGroup;
using Netflix_Server.Repository;

namespace Netflix_Server.Controllers.MovieGroup
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaybacksController : ControllerBase
    {
        private readonly IRepository<Playback> _playbackRepository;

        public PlaybacksController(IRepository<Playback> playbackRepository)
        {
            _playbackRepository = playbackRepository;
        }

        // GET: api/Playbacks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playback>>> GetPlaybacks()
        {
            return await _playbackRepository.GetList();
        }

        // GET: api/Playbacks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Playback>> GetPlayback(int id)
        {
            var playback = await _playbackRepository.GetById(id);

            if (playback == null)
            {
                return NotFound();
            }

            return playback;
        }

        // PUT: api/Playbacks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayback(int id, Playback playback)
        {
            if (id != playback.Id)
            {
                return BadRequest();
            }

            _playbackRepository.Update(playback);

            try
            {
                await _playbackRepository.Save();
            }
            catch
            {
                if (!await _playbackRepository.Exists(id))
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

        // POST: api/Playbacks
        [HttpPost]
        public async Task<ActionResult<Playback>> PostPlayback(Playback playback)
        {
            await _playbackRepository.Create(playback);

            return CreatedAtAction("GetPlayback", new { id = playback.Id }, playback);
        }

        // DELETE: api/Playbacks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayback(int id)
        {
            await _playbackRepository.Delete(id);

            return NoContent();
        }
    }
}
