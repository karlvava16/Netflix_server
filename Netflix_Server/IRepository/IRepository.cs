using Netflix_Server.View_Model;

namespace Netflix_Server.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetList(Filter filter=null);
        Task<T> GetById(int id);
        Task<T> GetByName(string name);

        Task Create(T item);
        Task Update(T item);

        Task Delete(int id);
        Task Save();

        Task<bool> Exists(int id);
    }
}
