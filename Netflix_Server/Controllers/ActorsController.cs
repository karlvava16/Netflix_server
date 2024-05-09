using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Netflix_Server.Models;
using Netflix_Server.Repository;

namespace Netflix_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly ActorRepository _actorRepository;

        public ActorsController(ActorRepository repo)
        {
            _actorRepository = repo;
        }

        // GET: api/Actors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> GetActors()
        {
            return await _actorRepository.GetList();
        }

        // GET: api/Actors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Actor>> GetActor(int id)
        {
            var actor = await _actorRepository.GetById(id);

            if (actor == null)
            {
                return NotFound();
            }

            return actor;
        }

        // PUT: api/Actors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActor(int id, Actor actor)
        {
            if (id != actor.Id)
            {
                return BadRequest();
            }

            _actorRepository.Update(actor);

            try
            {
                await _actorRepository.Save();
            }
            catch
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Actors
        [HttpPost]
        public async Task<ActionResult<Actor>> PostActor(Actor actor)
        {
            await _actorRepository.Create(actor);

            return CreatedAtAction("GetActor", new { id = actor.Id }, actor);
        }

        // DELETE: api/Actors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            await _actorRepository.Delete(id);

            return NoContent();
        }
    }
}
