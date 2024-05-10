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
    public class MovieImageRepository : IRepository<MovieImage>
    {
        private readonly MovieContext _context;

        public MovieImageRepository(MovieContext context)
        {
            _context = context;
        }

        public async Task Create(MovieImage item)
        {
            await _context.MovieImages.AddAsync(item);
        }

        public async Task Delete(int id)
        {
            var movieImage = await GetById(id);
            if (movieImage != null)
            {
                _context.MovieImages.Remove(movieImage);
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.MovieImages.AnyAsync(mi => mi.Id == id);
        }

        public async Task<MovieImage> GetById(int id)
        {
            return await _context.MovieImages.FindAsync(id);
        }

        public async Task<MovieImage> GetByName(string name)
        {
            return await _context.MovieImages.FirstOrDefaultAsync(mi => mi.PosterPath == name);
        }

        public async Task<List<MovieImage>> GetList(Filter filter=null)
        {
            return await _context.MovieImages.ToListAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public Task Update(MovieImage item)
        {
            _context.MovieImages.Update(item);
            return Task.CompletedTask;
        }
    }
}
