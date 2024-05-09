using Netflix_Server.IRepositorys;
using Netflix_Server.Models;

namespace Netflix_Server.Repository
{
    public class GenreRepository : IRepository<Genre>
    {
        public Task Create(Genre item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Genre> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Genre> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Genre>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Genre item)
        {
            throw new NotImplementedException();
        }
    }
}
