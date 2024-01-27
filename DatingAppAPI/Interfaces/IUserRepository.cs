using DatingAppAPI.DTOs;
using DatingAppAPI.Entities;
using DatingAppAPI.Helpers;

namespace DatingAppAPI.Interfaces
{
    public interface IUserRepository : IGenericRepository<AppUser>
    {
        Task<AppUser> GetUserByUserName(string username);
        Task<bool> IsUserExists(string username);
        Task<PagedList<MemberDto>> GetMemebers(UserParams userParams);
        Task<MemberDto> GetMemberByUserName(string username);
    }
}
