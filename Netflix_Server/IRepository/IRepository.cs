namespace Netflix_Server.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<T> GetByName(string name);

        Task <List<T>> GetList();

        Task Create(T item);
        Task Update(T item);

        Task Delete(int id);
        Task Save();

        Task<bool> Exists(int id);
    }
}
