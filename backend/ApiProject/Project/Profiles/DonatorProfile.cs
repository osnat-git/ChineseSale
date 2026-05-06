using AutoMapper;
using Project.Models;
using Project.Models.ModelsDTO;

namespace Project.Profiles
{
    public class DonorProfile: Profile
    {
        public DonorProfile()
        {
            CreateMap<DonorDTO, Donor>()
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
