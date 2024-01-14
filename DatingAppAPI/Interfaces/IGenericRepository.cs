
namespace DatingAppAPI.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        void Update(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        void Create(T entity);
    }
}
