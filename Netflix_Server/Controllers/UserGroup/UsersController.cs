using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netflix_Server.Models.Context;
using Netflix_Server.Models.UserGroup;
using Netflix_Server.IRepository;
using Netflix_Server.Services.UserGroup;


namespace Netflix_Server.Controllers.UserGroup
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> _repository;
        private readonly IUserAuthentication _authService;

        public UsersController(IRepository<User> repository, IUserAuthentication authService)
        {
            _repository = repository;
            _authService = authService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _repository.GetList(null);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _repository.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }


        // GET: api/Users/5
        [HttpGet("email/{email}")]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {
            var user = await _repository.GetById(1);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _repository.Update(user);
            await _repository.Save();

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(string email, string password, int pricingPlanId)
        {
            var result = await _authService.RegisterUserAsync(email, password, pricingPlanId);  /*Результат либо null, либо user */


            //await _repository.Create(user);
            //await _repository.Save();


            //return CreatedAtAction("GetUser", new { id = user.Id }, user);
            return Ok(result);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _repository.Delete(id);
            await _repository.Save();

            return NoContent();
        }
    }
}
