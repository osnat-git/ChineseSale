using Project.Models;
using Project.Models.ModelsDTO;

namespace Project.BLL.Interfaces
{
    public interface IAuthBll
    {
        Task<Result<string>> LoginUserAsync(string email, string password);
        Task<Result<User>> RegisterUserAsync(UserDTO userDTO);
    }
}
