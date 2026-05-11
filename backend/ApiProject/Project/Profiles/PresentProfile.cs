using AutoMapper;
using Project.Models;
using Project.Models.ModelsDTO;

namespace Project
{
    public class PresentProfile: Profile
    {
        public PresentProfile()
        {
            CreateMap<PresentDto, Present>()
                //.ForMember(x => x.Id, y => y.MapFrom(s => Identity()))
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
