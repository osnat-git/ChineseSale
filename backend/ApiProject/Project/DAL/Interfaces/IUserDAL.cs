using Project.Models;

namespace Project.DAL.Interfaces
{
    public interface IAuthDAL
    {
        Task<Result<string>> LoginUserAsync(string email, string password);
        Task<Result<User>> RegisterUserAsync(User user);
        Task<bool> DuplicateEmail(string email);
    }
}
