using AutoMapper;
using Project.BLL.Interfaces;
using Project.DAL.Interfaces;
using Project.Models;
using Project.Models.ModelsDTO;

namespace Project.BLL
{
    public class CategoryService : ICategoryService
    {
        ICategoryDal _cardDal;
        IMapper _mapper;
        public CategoryService(ICategoryDal cardDal, IMapper mapper)
        {
            _cardDal = cardDal;
            _mapper = mapper;
        }
    }
}