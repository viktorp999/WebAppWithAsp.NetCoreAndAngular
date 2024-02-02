﻿
namespace DatingAppAPI.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        ILikeRepository LikeRepository { get; }
        Task<bool> Complete();
    }
}
