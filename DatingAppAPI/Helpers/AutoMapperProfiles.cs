using AutoMapper;
using DatingAppAPI.DTOs;
using DatingAppAPI.Entities;
using DatingAppAPI.Extensions;

namespace DatingAppAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.PhotoUrl, options => options
                .MapFrom(scr => scr.Photos
                .FirstOrDefault(x => x.IsMain).Url))

                .ForMember(dest => dest.Age, options => options
                .MapFrom(scr => scr.DateOfBirth.CalculateAge()));

            CreateMap<Photo, PhotoDto>();
            CreateMap<MemberUpdateDto, AppUser>();
            CreateMap<RegisterDto, AppUser>();

            CreateMap<Message, MessageDto>()
                .ForMember(m => m.SenderPhotoUrl, o => o
                .MapFrom(s => s.Sender.Photos
                .FirstOrDefault(x => x.IsMain).Url))

                .ForMember(m => m.RecipientPhotoUrl, o => o
                .MapFrom(s => s.Recipient.Photos
                .FirstOrDefault(x => x.IsMain).Url));
        }
    }
}
