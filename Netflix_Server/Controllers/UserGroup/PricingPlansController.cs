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
    public class PricingPlansController : ControllerBase
    {
        private readonly IRepository<PricingPlan> _repository;

        public PricingPlansController(IRepository<PricingPlan> repository)
        {
            _repository = repository;
        }

        // GET: api/PricingPlans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PricingPlan>>> GetPricingPlan()
        {
            return await _repository.GetList();
        }

        // GET: api/PricingPlans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PricingPlan>> GetPricingPlan(int id)
        {
            var pricingplan = await _repository.GetById(id);

            if (pricingplan == null)
            {
                return NotFound();
            }

            return pricingplan;
        }

        // PUT: api/PricingPlans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPricingPlan(int id, PricingPlan pricingplan)
        {
            if (id != pricingplan.Id)
            {
                return BadRequest();
            }

            _repository.Update(pricingplan);
            await _repository.Save();

            return NoContent();
        }

        // POST: api/PricingPlans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PricingPlan>> PostPricingPlan(PricingPlan pricingplan)
        {
            await _repository.Create(pricingplan);
            await _repository.Save();

            return CreatedAtAction("GetPricingPlan", new { id = pricingplan.Id }, pricingplan);
        }

        // DELETE: api/PricingPlans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePricingPlan(int id)
        {
            await _repository.Delete(id);
            await _repository.Save();

            return NoContent();
        }
    }
}
