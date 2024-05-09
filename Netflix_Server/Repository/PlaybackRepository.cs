using Netflix_Server.IRepositorys;
using Netflix_Server.Models;

namespace Netflix_Server.Repository
{
    public class PlaybackRepository : IRepository<Playback>
    {
        public Task Create(Playback item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Playback> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Playback> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Playback>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Playback item)
        {
            throw new NotImplementedException();
        }
    }
}
