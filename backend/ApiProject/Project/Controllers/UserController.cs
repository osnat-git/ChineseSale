using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL;
using Project.BLL.Interfaces;
using Project.DAL.Interfaces;
using Project.Models;
using Project.Models.ModelsDTO;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/auth")] // הוספתי את הנתיב הבסיסי כאן
    public class UserController : ControllerBase
    {
        private readonly IAuthBll _userService;

        public UserController(IAuthBll userService)
        {
            _userService = userService; 
        }

        // משתמש ב-POST על נתיב "login" ומצפה לשלוח את הנתונים ב-Body
        [HttpPost("login")] 
        public async Task<Result<string>> LoginUserAsync([FromBody] LoginDTO loginDTO) // שים לב לשימוש ב-FromBody
        {
            return await _userService.LoginUserAsync(loginDTO.Email, loginDTO.Password);
        }

        // משתמש ב-POST על נתיב "register" ומצפה לשלוח את הנתונים ב-Body
        [HttpPost("register")] 
        public async Task<Result<User>> RegisterUserAsync([FromBody] UserDTO userDTO) // שים לב לשימוש ב-FromBody
        {
            return await _userService.RegisterUserAsync(userDTO);
        }
    }
}
