using AutoMapper;
using Pubs.Application.DTOs;
using Pubs.CoreDomain.Entities;

namespace Pubs.API.Profiles
{
    public class AuthorsProfile : Profile
    {
        public AuthorsProfile()
        {
            CreateMap<Author, AuthorDto>()
                    .ForMember(
                        dest => dest.Name,
                        opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                    .ForMember(dest => dest.AuthorId, org => org.MapFrom(src => src.Id))
                    .ForMember(dest => dest.IsAuthorUnderContract, org => org.MapFrom(src => src.Contract));

            CreateMap<AuthorCreateDto, Author>();

            CreateMap<AuthorUpdateDto, Author>();
        }
    }
}
