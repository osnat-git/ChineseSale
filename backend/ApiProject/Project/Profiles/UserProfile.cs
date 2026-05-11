using AutoMapper;
using Project.Models;
using Project.Models.ModelsDTO;

namespace Project.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>()
                //.ForMember(x => x.Id, y => y.MapFrom(s => Identity()))
                .ForMember(x => x.RegisterationTime, y => y.MapFrom(s => DateTime.Now))
                .ForMember(x => x.Role, y => y.MapFrom(s => "User"))
                .ForMember(x => x.IsActive, y => y.MapFrom(s => true));
        }
        static int Id = 0;
        private int Identity()
        {
            Id++;
            return Id;
        }
    }
}