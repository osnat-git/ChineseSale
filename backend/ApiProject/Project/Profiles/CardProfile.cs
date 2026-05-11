using AutoMapper;
using Project.Models;
using Project.Models.ModelsDTO;

namespace Project
{
    public class CardProfile: Profile
    {
        public CardProfile()
        {
            CreateMap<CardDto, Card>()
                //.ForMember(x => x.Id, y => y.MapFrom(s => Identity()))
                .ForMember(x => x.IsPaid, y => y.MapFrom(s => false))
                .ForMember(x => x.CreatedAt, y => y.MapFrom(s => DateTime.Now));
        }
        static int Id = 0;
        private int Identity()
        {
            Id++;
            return Id;
        }
    }
}
