using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Netflix_Server.IRepository;
using Netflix_Server.Models.Context;
using Netflix_Server.Models.MovieGroup;
using Netflix_Server.View_Model;


namespace Netflix_Server.Repository.MovieGroup
{
    public class MovieStatusRepository : IRepository<MovieStatus>
    {
        private readonly MovieContext _context;

        public MovieStatusRepository(MovieContext context)
        {
            _context = context;
        }

        public async Task Create(MovieStatus item)
        {
            await _context.MovieStatus.AddAsync(item);
        }

        public async Task Delete(int id)
        {
            var movieStatus = await GetById(id);
            if (movieStatus != null)
            {
                _context.MovieStatus.Remove(movieStatus);
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.MovieStatus.AnyAsync(ms => ms.Id == id);
        }

        public async Task<MovieStatus> GetById(int id)
        {
            return await _context.MovieStatus.FindAsync(id);
        }

        public async Task<MovieStatus> GetByName(string name)
        {
            return await _context.MovieStatus.FirstOrDefaultAsync(ms => ms.Film.Title == name);
        }

        public async Task<List<MovieStatus>> GetList(Filter filter = null)
        {
            return await _context.MovieStatus.ToListAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public Task Update(MovieStatus item)
        {
            _context.MovieStatus.Update(item);
            return Task.CompletedTask;
        }
    }
}
