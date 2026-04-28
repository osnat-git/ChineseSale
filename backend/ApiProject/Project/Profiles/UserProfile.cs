using AutoMapper;
using Project.Models;
using Project.Models.ModelsDTO;

namespace Project.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, User>()
                .ForMember(x => x.Role, y => y.MapFrom(s => "User"));
        }
    }
}
