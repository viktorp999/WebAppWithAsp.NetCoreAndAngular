using AutoMapper;
using DatingAppAPI.Interfaces;

namespace DatingAppAPI.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public IUserRepository UserRepository { get; private set; }
        public ILikeRepository LikeRepository { get; private set; }
        public IMessageRepository MessageRepository { get; private set; }

        public UnitOfWork(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            UserRepository = new UserRepository(_context, _mapper);
            LikeRepository = new LikeRepository(_context, _mapper);
            MessageRepository = new MessageRepository(_context, _mapper);
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
