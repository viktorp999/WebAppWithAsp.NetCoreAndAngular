using AutoMapper;
using DatingAppAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DatingAppAPI.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DataContext context;
        protected readonly IMapper mapper;
        private readonly DbSet<T> _dbset;

        public GenericRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            _dbset = this.context.Set<T>();
        }
        public async Task<T> GetById(Guid id)
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

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }
    }
}
