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
                    .ForMember(d => d.AuthorId, o => o.MapFrom(src => src.Id));

            CreateMap<AuthorCreationDto, Author>();

        }
    }
}
