using AutoMapper;
using Pubs.Application.DTOs;
using Pubs.CoreDomain.Entities;

namespace Pubs.API.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDto>()
                    .ForMember(
                        dest => dest.Name,
                        opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                    .ForMember(dest => dest.Contract, org => org.MapFrom(src => src.Contract));

            CreateMap<AuthorCreateDto, Author>();

            CreateMap<AuthorUpdateDto, Author>();

            CreateMap<AuthorUpdateAuthorCodeDto, Author>();

            CreateMap<AuthorUpdateContractDto, Author>();

        }
    }
}
