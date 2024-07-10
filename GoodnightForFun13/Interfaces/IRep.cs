namespace GoodnightForFun13.Interfaces
{
    public interface IRep<T>
        where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task Add(T item);
        Task Delete(int id);
        Task Update(int id, T newItem);
        void Save();
    }
}
