using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netflix_Server.Models.Context;
using Netflix_Server.Models.UserGroup;
using Netflix_Server.IRepository;

namespace Netflix_Server.Controllers.UserGroup
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IRepository<Feature> _repository;

        public FeaturesController(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        // GET: api/Features
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feature>>> GetFeature()
        {
            return await _repository.GetList();
        }

        // GET: api/Features/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feature>> GetFeature(int id)
        {
            var feature = await _repository.GetById(id);

            if (feature == null)
            {
                return NotFound();
            }

            return feature;
        }

        // PUT: api/Features/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeature(int id, Feature feature)
        {
            if (id != feature.Id)
            {
                return BadRequest();
            }

            _repository.Update(feature);
            await _repository.Save();

            return NoContent();
        }

        // POST: api/Features
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Feature>> PostFeature(Feature feature)
        {
            await _repository.Create(feature);
            await _repository.Save();

            return CreatedAtAction("GetFeature", new { id = feature.Id }, feature);
        }

        // DELETE: api/Features/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            await _repository.Delete(id);
            await _repository.Save();

            return NoContent();
        }
    }
}
