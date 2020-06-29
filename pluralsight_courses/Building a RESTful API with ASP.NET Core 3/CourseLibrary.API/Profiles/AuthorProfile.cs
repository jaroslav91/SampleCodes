using AutoMapper;
using CourseLibrary.API.Helpers;

namespace CourseLibrary.API.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Entities.Author, Models.AuthorDto>()
            .ForMember(dest => dest.Age , o => o.MapFrom(src => src.DateOfBirth.GetCurrentAge()))
            .ForMember(dest => dest.Name, opt => opt.MapFrom (src => string.Format("{0} {1}", src.FirstName, src.LastName)));            
        }
    }
}