using AutoMapper;
using Pubs.Application.DTOs;
using Pubs.CoreDomain.Entities;

namespace Pubs.API.Profiles
{
    public class AuthorTitleProfile : Profile
    {
        public AuthorTitleProfile()
        {
            CreateMap<AuthorTitle, AuthorTitleDto>()
                .ForMember(dest => dest.AuthorTitleId, org => org.MapFrom(src => src.Id))
                .ForMember(dest => dest.TitleName, org => org.MapFrom(src => src.Title.TitleName))
                .ForMember(dest => dest.TitleCode, org => org.MapFrom(src => src.Title.TitleCode))
                .ForMember(dest => dest.TitleType, org => org.MapFrom(src => src.Title.TitleType));
        }
    }
}
