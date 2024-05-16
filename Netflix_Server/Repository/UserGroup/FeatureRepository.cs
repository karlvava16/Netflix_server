using Netflix_Server.IRepository;
using Netflix_Server.Models.UserGroup;
using Netflix_Server.Models.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Netflix_Server.Repository.UserGroup
{
    public class FeatureRepository : IRepository<Feature>
    {
        private readonly MovieContext _context;

        public FeatureRepository(MovieContext context)
        {
            _context = context;
        }

        public async Task Create(Feature item)
        {
            _context.Features.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var feature = await _context.Features.FindAsync(id);
            if (feature != null)
            {
                _context.Features.Remove(feature);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Features.AnyAsync(e => e.Id == id);
        }

        public async Task<Feature> GetById(int id)
        {
            return await _context.Features.FindAsync(id);
        }

        public async Task<Feature> GetByName(string name)
        {
            return await _context.Features.FirstOrDefaultAsync(f => f.Name == name);
        }

        public async Task<List<Feature>> GetList()
        {
            return await _context.Features.ToListAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(Feature item)
        {
            _context.Entry(item).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await Exists(item.Id))
                {
                    throw new Exception("Feature not found");
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
