using Project.BLL.Interfaces;
using Project.DAL.Interfaces;
using Project.Models;

namespace Project.BLL
{
    public class WinnerService : IWinnerService
    {
        private readonly IWinnerDAL _winnerDAL;
        private readonly IEmailService _emailService;
        
        public WinnerService(IWinnerDAL winnerDAL, IEmailService emailService)
        {
            _winnerDAL = winnerDAL;
            _emailService = emailService;
        }

        public async Task<Result<Winner>> DrawWinnerForPresentAsync(int presentId)
        {
            if (presentId <= 0)
            {
                return new Result<Winner>
                {
                    Success = false,
                    Message = "Invalid present id",
                    Data = null
                };
            }

            return await _winnerDAL.DrawWinnerForPresentAsync(presentId);
        }

        public async Task<Result<Dictionary<Present, List<User>>>> GetPresentsWithUsersAsync()
        {
            return await _winnerDAL.GetPresentsWithUsersAsync();
        }
        public async Task<decimal> CalculateTotalIncomeForPresentAsync()
        {
            return await _winnerDAL.CalculateTotalIncomeForPresentAsync();
        }
        public async Task<Result<string>> SendWinnerEmailAsync()
        {
            return await _emailService.SendAllWinnersEmailAsync();
        }
    }
}
