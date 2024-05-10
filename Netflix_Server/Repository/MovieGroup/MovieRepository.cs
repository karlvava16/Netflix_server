using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Netflix_Server.IRepository;
using Netflix_Server.Models.Context;
using Netflix_Server.Models.MovieGroup;
using Netflix_Server.View_Model;

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

        public async Task<List<Movie>> GetList(Filter filter = null)
        {
            IQueryable<Movie> query = _context.Movies;

            // Применяем фильтр, если он передан
            if (filter != null)
            {
                // Фильтрация по входному тексту
                if (!string.IsNullOrEmpty(filter.InputFilter))
                {
                    query = query.Where(m => m.Title.ToLower().Contains(filter.InputFilter.ToLower()));
                }

                // Фильтрация по жанрам
                if (filter.GenresIdFilter != null && filter.GenresIdFilter.Length > 0)
                {
                    query = query.Where(m => m.Genres.Any(g => filter.GenresIdFilter.Contains(g.Id)));
                }
            }

            if (filter != null && filter.CurrentPage > 0 && filter.Elements > 0)
            {
                int skipCount = (filter.CurrentPage - 1) * filter.Elements;
                query = query.Skip(skipCount).Take(filter.Elements);
            }


            return await query.ToListAsync();

        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public Task Update(Movie item)
        {
            _context.Movies.Update(item);
            return Task.CompletedTask;

        }
    }
}
