using Project.Models;

namespace Project.DAL.Interfaces
{
    public interface ICardDAL
    {
        Task<Result<Card>> GetCardsByAllPresentsAsync();
        Task<Result<Card>> GetMostExpensiveCardsAsync();
        Task<Result<User>> GetAllCardBuyersAsync();
        Task<Result<Card>> GetCardsByUserAsync(int userId);
        Task<Result<Card>> GetUnpaidCardsAsync(int userId);
        Task<Result<Card>> GetCardsByQuantityAsync();
        Task<Result<Card>> DeleteCardAsync(int cardId);
        Task<Result<Card>> PurchaseCardAsync(Card card);
        Task<Result<Card>> ProcessPaymentForUserAsync(int userId);
    }
}
