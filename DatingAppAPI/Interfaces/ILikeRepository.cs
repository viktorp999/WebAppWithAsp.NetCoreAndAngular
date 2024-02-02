using DatingAppAPI.DTOs;
using DatingAppAPI.Entities;

namespace DatingAppAPI.Interfaces
{
    public interface ILikeRepository : IGenericRepository<UserLike>
    {
        Task<UserLike> GetUserLike(Guid sourceUserId, Guid targetUserId);
        Task<AppUser> GetUserWithLikes(Guid userId);
        Task<IEnumerable<LikeDto>> GetUserLikes(string predicate, Guid userId);
    }
}
