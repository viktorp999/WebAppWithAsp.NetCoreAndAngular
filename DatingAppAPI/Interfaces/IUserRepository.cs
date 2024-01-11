using DatingAppAPI.DTOs;
using DatingAppAPI.Entities;

namespace DatingAppAPI.Interfaces
{
    public interface IUserRepository : IGenericRepository<AppUser>
    {
        Task<AppUser> GetUserByUserName(string username);
        Task<bool> IsUserExists(string username);
        Task<IEnumerable<MemberDto>> GetMemebers();
        Task<MemberDto> GetMemberByUserName(string username);
    }
}
