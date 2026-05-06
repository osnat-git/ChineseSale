using AutoMapper;
using Project.Models;
using Project.Models.ModelsDTO;

namespace Project
{
    public class PresentProfile: Profile
    {
        public PresentProfile()
        {
            CreateMap<PresentDTO, Present>()
                .ForMember(x => x.Id, y => y.MapFrom(s => Identity()));
        }
        static int Id = 0;
        private int Identity()
        {
            Id++;
            return Id;
        }
    }
}
