using Project.Models;

namespace Project.DAL.Interfaces
{
    public interface IWinnerDAL
    {
        Task<Result<Winner>> DrawWinnerForPresentAsync(int presentId);
        Task<Result<Dictionary<Present, List<User>>>> GetPresentsWithUsersAsync();
        // Task<Result<Models.ModelsDTO.WinnerPresentNameDTO>> GetWinnersWithPresentNamesAsync();
        Task<decimal> CalculateTotalIncomeForPresentAsync();
    }
}
