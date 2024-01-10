using DatingAppAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DatingAppAPI.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DataContext context;
        private readonly DbSet<T> _dbset;

        public GenericRepository(DataContext context)
        {
            this.context = context;
            _dbset = this.context.Set<T>();
        }
        public async Task<T> GetById(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbset.ToListAsync();
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Create(T entity)
        {
            _dbset.Add(entity);
        }
    }
}
