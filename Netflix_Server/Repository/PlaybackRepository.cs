using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Netflix_Server.IRepositorys;
using Netflix_Server.Models;

namespace Netflix_Server.Repository
{
    public class PlaybackRepository : IRepository<Playback>
    {
        private readonly MovieContext _context;

        public PlaybackRepository(MovieContext context)
        {
            _context = context;
        }

        public async Task Create(Playback item)
        {
            await _context.Playbacks.AddAsync(item);
        }

        public async Task Delete(int id)
        {
            var playback = await GetById(id);
            if (playback != null)
            {
                _context.Playbacks.Remove(playback);
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Playbacks.AnyAsync(p => p.Id == id);
        }

        public async Task<Playback> GetById(int id)
        {
            return await _context.Playbacks.FindAsync(id);
        }

        public async Task<Playback> GetByName(string name)
        {
            return await _context.Playbacks.FirstOrDefaultAsync(p => p.Path == name);
        }

        public async Task<List<Playback>> GetList()
        {
            return await _context.Playbacks.ToListAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Playback item)
        {
            _context.Playbacks.Update(item);
        }
    }
}
