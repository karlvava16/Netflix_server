namespace Netflix_Server.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetList();
        Task<T> GetById(int id);
        Task<T> GetByName(string name);

        Task Create(T item);
        void Update(T item);

        Task Delete(int id);
        Task Save();




    }
}
