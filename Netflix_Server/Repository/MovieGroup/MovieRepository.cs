using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Netflix_Server.IRepository;
using Netflix_Server.Models.Context;
using Netflix_Server.Models.MovieGroup;

namespace Netflix_Server.Repository.MovieGroup
{
    public class MovieRepository : IRepository<Movie>
    {
        private readonly MovieContext _context;

        public MovieRepository(MovieContext context)
        {
            _context = context;
        }

        public async Task Create(Movie item)
        {
            await _context.Movies.AddAsync(item);
        }

        public async Task Delete(int id)
        {
            var movie = await GetById(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Movies.AnyAsync(m => m.Id == id);
        }

        public async Task<Movie> GetById(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<Movie> GetByName(string name)
        {
            return await _context.Movies.FirstOrDefaultAsync(m => m.Title == name);
        }

        public async Task<List<Movie>> GetList()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Movie item)
        {
            _context.Movies.Update(item);
        }
    }
}
