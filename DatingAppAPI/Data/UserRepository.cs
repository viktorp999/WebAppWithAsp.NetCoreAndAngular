using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatingAppAPI.DTOs;
using DatingAppAPI.Entities;
using DatingAppAPI.Helpers;
using DatingAppAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DatingAppAPI.Data
{
    public class UserRepository : GenericRepository<AppUser>, IUserRepository
    {
        public UserRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
            
        }

        public async Task<MemberDto> GetMemberByUserName(string username)
        {
            var member = await context.Users.Where(x => x.UserName == username).
                ProjectTo<MemberDto>(mapper.ConfigurationProvider).
                SingleOrDefaultAsync();

            return member;
        }

        public async Task<PagedList<MemberDto>> GetMemebers(UserParams userParams)
        {
            var query = context.Users.ProjectTo<MemberDto>(mapper.ConfigurationProvider).AsNoTracking();

            return await PagedList<MemberDto>.Create(query, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<AppUser> GetUserByUserName(string username)
        {
            return await context.Users.Include(p => p.Photos).SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<bool> IsUserExists(string username)
        {
            return await context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}
