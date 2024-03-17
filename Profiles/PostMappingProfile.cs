
using AutoMapper;
using ypost_backend_dotnet.Entities;
using ypost_backend_dotnet.Models;

namespace ypost_backend_dotnet.Profiles
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<Entry, PostDto>()
                .ForMember(m => m.NumOfComments, c => c.MapFrom(m => m.Comments.Count))
                .ForMember(m => m.Author, c => c.MapFrom(m => new UserMinimalDto()
                {
                    Id = m.Author.Id,
                    UserName = m.Author.UserName,
                    FirstName = m.Author.FirstName,
                    LastName = m.Author.LastName,
                    Image = m.Author.Image,
                    Bio = m.Author.Bio,

                }));

            CreateMap<Entry, FullPostDto>()
                .ForMember(m => m.Author, c => c.MapFrom(m => new UserMinimalDto()
                {
                    Id = m.Author.Id,
                    UserName = m.Author.UserName,
                    FirstName = m.Author.FirstName,
                    LastName = m.Author.LastName,
                    Image = m.Author.Image,
                    Bio = m.Author.Bio,

                }));

            CreateMap<UserDto, User>();

            //CreateMap<UserMinimalDto, Entry>()
            //     .ForMember(m => m.Author, c => c.MapFrom(m => new UserMinimalDto()
            //     {
            //         Id = m.Id,
            //         UserName = m.UserName,
            //         FirstName = m.FirstName,
            //         LastName = m.LastName,
            //         Image = m.Image,
            //         Bio = m.Bio,

            //     }));
        }
    }
}
