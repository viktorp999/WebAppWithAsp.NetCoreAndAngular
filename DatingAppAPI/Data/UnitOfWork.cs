using DatingAppAPI.Interfaces;

namespace DatingAppAPI.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public IUserRepository UserRepository { get; private set; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
        }

        public  async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
