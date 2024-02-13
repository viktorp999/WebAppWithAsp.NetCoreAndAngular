using AutoMapper;
using DatingAppAPI.DTOs;
using DatingAppAPI.Entities;
using DatingAppAPI.Extensions;
using DatingAppAPI.Helpers;
using DatingAppAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DatingAppAPI.Data
{
    public class LikeRepository : GenericRepository<UserLike>, ILikeRepository
    {
        public LikeRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public async Task<UserLike> GetUserLike(Guid sourceUserId, Guid targetUserId)
        {
            return await context.Likes.FindAsync(sourceUserId, targetUserId);
        }

        public async Task<PagedList<LikeDto>> GetUserLikes(LikesParams likesParams)
        {
            var users = context.Users.OrderBy(u => u.UserName).AsQueryable();
            var likes = context.Likes.AsQueryable();

            if (likesParams.Predicate == "liked")
            {
                likes = likes.Where(like => like.SourceUserId == likesParams.UserId);
                users = likes.Select(like => like.TargetUser);
            }

            if (likesParams.Predicate == "likedBy")
            {
                likes = likes.Where(like => like.TargetUserId == likesParams.UserId);
                users = likes.Select(like => like.SourceUser);
            }

            var likedUsers = users.Select(user => new LikeDto
            {
                Id = user.Id,
                UserName = user.UserName,
                KnownAs = user.KnownAs,
                Age = user.DateOfBirth.CalculateAge(),
                PhotoUrl = user.Photos.FirstOrDefault(x => x.IsMain).Url,
                City = user.City
            });

            return await PagedList<LikeDto>.Create(likedUsers, likesParams.PageNumber, likesParams.PageSize);
        }

        public async Task<AppUser> GetUserWithLikes(Guid userId)
        {
            return await context.Users.Include(x => x.LikedUsers).FirstOrDefaultAsync(x => x.Id == userId);
        }
    }
}
