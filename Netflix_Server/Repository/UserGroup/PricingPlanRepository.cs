using Netflix_Server.IRepository;
using Netflix_Server.Models.UserGroup;
using Netflix_Server.Models.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Netflix_Server.View_Model;

namespace Netflix_Server.Repository.UserGroup
{
    public class PricingPlanRepository : IRepository<PricingPlan>
    {
        private readonly MovieContext _context;

        public PricingPlanRepository(MovieContext context)
        {
            _context = context;
        }

        public async Task Create(PricingPlan item)
        {
            _context.PricingPlans.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var pricingplan = await _context.PricingPlans.FindAsync(id);
            if (pricingplan != null)
            {
                _context.PricingPlans.Remove(pricingplan);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.PricingPlans.AnyAsync(e => e.Id == id);
        }

        public async Task<PricingPlan> GetById(int id)
        {
            return await _context.PricingPlans.FindAsync(id);
        }

        public async Task<PricingPlan> GetByName(string name)
        {
            return await _context.PricingPlans.FirstOrDefaultAsync(f => f.Name == name);
        }

        public async Task<List<PricingPlan>> GetList(Filter filter=null)
        {
            return await _context.PricingPlans.ToListAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(PricingPlan item)
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
                    throw new Exception("PricingPlan not found");
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
