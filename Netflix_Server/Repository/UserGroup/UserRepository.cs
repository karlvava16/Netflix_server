using Netflix_Server.IRepository;
using Netflix_Server.Models.UserGroup;
using Netflix_Server.Models.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Netflix_Server.Repository.UserGroup
{
    public class UserRepository : IRepository<User>
    {
        private readonly MovieContext _context;

        public UserRepository(MovieContext context)
        {
            _context = context;
        }

        public async Task Create(User item)
        {
            _context.Users.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Users.AnyAsync(e => e.Id == id);
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetByName(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(f => f.Name == name);
        }

        public async Task<List<User>> GetList()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async void Update(User item)
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
                    throw new Exception("User not found");
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
