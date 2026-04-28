using Project.Models;
using Project.Models.ModelsDTO;

namespace Project.DAL.Interfaces
{
    public interface IAuthDal
    {
        Task Register(User user);
    }
}
