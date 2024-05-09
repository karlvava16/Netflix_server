using Netflix_Server.IRepositorys;
using Netflix_Server.Models;

namespace Netflix_Server.Repository
{
    public class MovieRepository : IRepository<Movie>
    {
        private readonly MovieContext _context;
        public MovieRepository(MovieContext context)
        {
            _context = context;
        }
        public Task Create(Movie item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Movie item)
        {
            throw new NotImplementedException();
        }
    }
}
