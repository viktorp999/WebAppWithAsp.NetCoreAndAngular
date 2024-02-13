using DatingAppAPI.DTOs;
using DatingAppAPI.Entities;
using DatingAppAPI.Helpers;

namespace DatingAppAPI.Interfaces
{
    public interface ILikeRepository : IGenericRepository<UserLike>
    {
        Task<UserLike> GetUserLike(Guid sourceUserId, Guid targetUserId);
        Task<AppUser> GetUserWithLikes(Guid userId);
        Task<PagedList<LikeDto>> GetUserLikes(LikesParams likesParams);
    }
}
