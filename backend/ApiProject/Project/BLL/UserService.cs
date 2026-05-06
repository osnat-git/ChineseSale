using AutoMapper;
using Project.BLL.Interfaces;
using Project.DAL;
using Project.DAL.Interfaces;
using Project.Models;
using Project.Models.ModelsDTO;
using Project.Validators;
using System.Text.RegularExpressions;

namespace Project.BLL
{
    public class AuthService : IAuthBll
    {
        IAuthDAL _userDAL;
        IMapper _mapper;
        public AuthService(IAuthDAL user, IMapper mapper)
        {
            _userDAL = user;
            _mapper = mapper;
        }


        public async Task<Result<string>> LoginUserAsync(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return new Result<string>
                {
                    Success = false,
                    Message = "Email and password are required",
                    Data = null
                };
            }

            if (!Validator.ValidEmail(email))
            {
                return new Result<string>
                {
                    Success = false,
                    Message = "Invalid email or password format",
                    Data = null
                };
            }

            return await _userDAL.LoginUserAsync(email, password);
        }

        public async Task<Result<User>> RegisterUserAsync(UserDTO userDTO)
        {
            if (userDTO != null && await _userDAL.DuplicateEmail(userDTO.Email) == false && Validator.ValidateData(userDTO.Name, userDTO.Email, userDTO.Phone))
            {
                var u = _mapper.Map<User>(userDTO);
                if(u == null)
                    return new Result<User>
                    {
                        Success = false,
                        Message = "failed to map object",
                        Data = null
                    };
                return await _userDAL.RegisterUserAsync(u);
            }
            return new Result<User>
            {
                Success = false,
                Message = "Error details",
                Data = null
            };
        }
    }
}