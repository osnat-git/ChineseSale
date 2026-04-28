using Project.DAL.Interfaces;
using Project.Models;

namespace Project.DAL
{
    public class AuthDal : IAuthDal
    {
        private readonly AppDBContext _dBContext;
        public AuthDal(AppDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task Register(User user)
        {
            await _dBContext.User.AddAsync(user);
        }
    }
}
