using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Netflix_Server.Models.MovieGroup;
using Netflix_Server.Models.MovieGroup.Context;
using Netflix_Server.Repository.MovieGroup;

namespace Netflix_Server.Controllers.MovieGroup
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorImagesController : ControllerBase
    {
        private readonly ActorImageRepository _actorImageRepository;

        public ActorImagesController(ActorImageRepository context)
        {
            _actorImageRepository = context;
        }

        // GET: api/Actors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActorImage>>> GetActors()
        {
            return await _actorImageRepository.GetList();
        }

        // GET: api/Actors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActorImage>> GetActor(int id)
        {
            var actor = await _actorImageRepository.GetById(id);

            if (actor == null)
            {
                return NotFound();
            }

            return actor;
        }

        // PUT: api/Actors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActor(int id, ActorImage actor)
        {
            if (id != actor.Id)
            {
                return BadRequest();
            }

            _actorImageRepository.Update(actor);

            try
            {
                await _actorImageRepository.Save();
            }
            catch
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Actors
        [HttpPost]
        public async Task<ActionResult<ActorImage>> PostActor(ActorImage actor)
        {
            await _actorImageRepository.Create(actor);

            return CreatedAtAction("GetActor", new { id = actor.Id }, actor);
        }

        // DELETE: api/Actors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            await _actorImageRepository.Delete(id);

            return NoContent();
        }
    }
}
