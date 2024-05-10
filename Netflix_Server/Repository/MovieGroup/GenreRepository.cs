using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Netflix_Server.IRepository;
using Netflix_Server.Models.Context;
using Netflix_Server.Models.MovieGroup;
using Netflix_Server.View_Model;

namespace Netflix_Server.Repository.MovieGroup
{
    public class GenreRepository : IRepository<Genre>
    {
        private readonly MovieContext _context;

        public GenreRepository(MovieContext context)
        {
            _context = context;
        }

        public async Task Create(Genre item)
        {
            await _context.Genres.AddAsync(item);
        }

        public async Task Delete(int id)
        {
            var genre = await GetById(id);
            if (genre != null)
            {
                _context.Genres.Remove(genre);
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Genres.AnyAsync(g => g.Id == id);
        }

        public async Task<Genre> GetById(int id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task<Genre> GetByName(string name)
        {
            return await _context.Genres.FirstOrDefaultAsync(g => g.Name == name);
        }

        public async Task<List<Genre>> GetList(Filter filter = null)
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public Task Update(Genre item)
        {
            _context.Genres.Update(item);
            return Task.CompletedTask;
        }
    }
}
