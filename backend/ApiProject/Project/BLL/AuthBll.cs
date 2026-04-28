using AutoMapper;
using Project.BLL.Interfaces;
using Project.DAL.Interfaces;
using Project.Models;
using Project.Models.ModelsDTO;

namespace Project.BLL
{
    public class AuthBll : IAuthBll
    {
        private readonly IAuthDal _authDal;
        private readonly IMapper _mapper;
        public AuthBll(IAuthDal authDal, IMapper mapper)
        {
            _authDal = authDal;
            _mapper = mapper;
        }

        public async Task Register(UserDTO userDTO)
        {
            var user = _mapper.Map<UserDTO, User>(userDTO);

            await _authDal.Register(user);
        }
    }
}
