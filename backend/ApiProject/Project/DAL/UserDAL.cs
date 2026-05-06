using BCrypt.Net;  // חשוב להשתמש ב-Bcrypt
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Project.DAL.Interfaces;
using Project.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL
{
    public class AuthDAL : IAuthDAL
    {
        private readonly AppDBContext dbContext;
        private readonly ILogger<AuthDAL> logger;
        private readonly JWTSettings jwtSettings;  // הוספת שדה להגדרות ה־JWT

        public AuthDAL(AppDBContext context, ILogger<AuthDAL> logger, IOptions<JWTSettings> jwtSettings)
        {
            dbContext = context;
            this.logger = logger;
            this.jwtSettings = jwtSettings.Value;
        }
        public async Task<Result<string>> LoginUserAsync(string email, string password)
        {
            try
            {
                // חיפוש המשתמש לפי המייל
                var user = await dbContext.User
                    .FirstOrDefaultAsync(u => u.Email == email); // לוודא שהמשתמש פעיל

                if (user == null)
                {
                    logger.LogWarning($"Login failed for email: {email}. User not found.");
                    return new Result<string>
                    {
                        Success = false,
                        Message = "One or more of the identification details are incorrect. Please try again."
                    };
                }

                // השוואת סיסמאות: האם הסיסמה שהוזנה תואמת לסיסמה המוצפנת
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.Password);

                if (!isPasswordValid)
                {
                    logger.LogWarning($"Failed login attempt for email: {email}. Incorrect password.");
                    return new Result<string>
                    {
                        Success = false,
                        Message = "One or more of the identification details are incorrect. Please try again."
                    };
                }

                // יצירת טוקן JWT
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(jwtSettings.SecretKey); // המפתח הסודי מתוך קובץ הקונפיגורציה
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Role)

            }),
                    Expires = DateTime.Now.AddHours(1.5),
                    Issuer = jwtSettings.Issuer, // המוציא את המידע מתוך קובץ הקונפיגורציה
                    Audience = jwtSettings.Audience, // קהל היעד מתוך קובץ הקונפיגורציה
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                logger.LogInformation($"User with email {email} logged in successfully.");
                return new Result<string>
                {
                    Success = true,
                    Message = tokenString // מחזירים את הטוקן בהודעה 
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred during the login process.");
                return new Result<string>
                {
                    Success = false,
                    Message = "An error occurred during login. Please try again later."
                };
            }
        }

        public async Task<bool> DuplicateEmail(string email)
        {
            try
            {
                var existingUser = await dbContext.User
                    .FirstOrDefaultAsync(u => u.Email == email);

                if (existingUser != null)
                {
                    logger.LogWarning($"User with email {email} already exists.");
                    return true;
                    //return new Result<string>
                    //{
                    //    Success = false,
                    //    Message = "Duplicate email",
                    //    Data = null
                    //};
                }
                //return new Result<string>
                //{
                //    Success = true,
                //    Message = "This email doesn't exist.",
                //    Data = null
                //};
                return false;
            }

            catch
            {
                logger.LogError("could not find check duplicate email");
                //return new Result<string>
                //{
                //    Success = true,
                //    Message = "This email doesn't exist.",
                //    Data = null
                //};
                return true;
            }
        }

        public async Task<Result<User>> RegisterUserAsync(User user)
        {
            try
            {
                // הצפנת הסיסמה לפני שמירתה במסד הנתונים
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                await dbContext.User.AddAsync(user);
                await dbContext.SaveChangesAsync();

                logger.LogInformation($"User with email {user.Email} registered successfully.");
                return new Result<User>
                {
                    Success = true,
                    Message = "User registered successfully.",
                    Data = new List<User> { user } // מחזירים את המשתמש שנרשם
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred during the registration process.");
                return new Result<User>
                {
                    Success = false,
                    Message = "An error occurred during the registration process. Please try again later.",
                    Data = null
                };
            }
        }
    }
}
