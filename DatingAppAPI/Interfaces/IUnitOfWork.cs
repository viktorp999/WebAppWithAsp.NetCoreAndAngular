
namespace DatingAppAPI.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        Task<bool> Complete();
    }
}
