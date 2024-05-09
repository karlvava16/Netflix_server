using Netflix_Server.IRepositorys;
using Netflix_Server.Models;

namespace Netflix_Server.Repository
{
    public class ActorRepository : IRepository<Actor>
    {
        public Task Create(Actor item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Actor> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Actor> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Actor>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Actor item)
        {
            throw new NotImplementedException();
        }
    }
}
