using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Netflix_Server.IRepositorys;
using Netflix_Server.Models.MovieGroup;
using Netflix_Server.Models.MovieGroup.Context;

namespace Netflix_Server.Repository.MovieGroup
{
    public class ActorImageRepository : IRepository<ActorImage>
    {
        private readonly MovieContext _context;

        public ActorImageRepository(MovieContext context)
        {
            _context = context;
        }

        public async Task Create(ActorImage item)
        {
            await _context.ActorImages.AddAsync(item);
        }

        public async Task Delete(int id)
        {
            var actorImage = await GetById(id);
            if (actorImage != null)
            {
                _context.ActorImages.Remove(actorImage);
            }
        }
        //Сделал
        public async Task<bool> Exists(int id)
        {
            return await _context.ActorImages.AnyAsync(ai => ai.Id == id);
        }

        public async Task<ActorImage> GetById(int id)
        {
            return await _context.ActorImages.FindAsync(id);
        }

        public async Task<ActorImage> GetByName(string name)
        {
            return await _context.ActorImages.FirstOrDefaultAsync(ai => ai.Alt == name);
        }

        public async Task<List<ActorImage>> GetList()
        {
            return await _context.ActorImages.ToListAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(ActorImage item)
        {
            _context.ActorImages.Update(item);
        }
    }
}
