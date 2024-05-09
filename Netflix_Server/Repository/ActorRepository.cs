using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Netflix_Server.IRepositorys;
using Netflix_Server.Models;

namespace Netflix_Server.Repository
{
    public class ActorRepository : IRepository<Actor>
    {
        private readonly MovieContext _context;

        public ActorRepository(MovieContext context)
        {
            _context = context;
        }

        public async Task Create(Actor item)
        {
            await _context.Actors.AddAsync(item);
        }

        public async Task Delete(int id)
        {
            var actor = await GetById(id);
            if (actor != null)
            {
                _context.Actors.Remove(actor);
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Actors.AnyAsync(a => a.Id == id);
        }

        public async Task<Actor> GetById(int id)
        {
            return await _context.Actors.FindAsync(id);
        }

        public async Task<Actor> GetByName(string name)
        {
            return await _context.Actors.FirstOrDefaultAsync(a => a.Name == name);
        }

        public async Task<List<Actor>> GetList()
        {
            return await _context.Actors.ToListAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Actor item)
        {
            _context.Actors.Update(item);
        }
    }
}
