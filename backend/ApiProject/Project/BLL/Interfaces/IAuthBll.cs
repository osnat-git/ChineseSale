using Project.Models.ModelsDTO;

namespace Project.BLL.Interfaces
{
    public interface IAuthBll
    {
        Task Register(UserDTO userDTO);
    }
}
