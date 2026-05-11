using AutoMapper;
using Project.BLL.Interfaces;
using Project.DAL.Interfaces;
using Project.Models;
using Project.Models.ModelsDTO;

namespace Project.BLL
{
    public class LotteryService : ILotteryService
    {
        IMapper _mapper;
        public LotteryService(IMapper mapper)
        {
            _mapper = mapper;
        }

//        public async Task<Result<Card>> PurchaseCardAsync(CardDTO cardDTO)
//        {
//            ///validation
//            if(cardDTO != null && cardDTO.PresentId > 0 && cardDTO.UserId > 0)
//            {
//                var c = _mapper.Map<Card>(cardDTO);
//                return await _cardDAL.PurchaseCardAsync(c);
//            }
//                return new Result<Card> { 
//                    Success = false,
//                    Message = "one of the details worng",
//                    Data = null
//                };
//        }
////
//        public async Task<Result<Card>> GetCardsWithPresentsAsync()
//        {
//            return await _cardDAL.GetCardsByAllPresentsAsync();
//        }

//        public async Task<Result<Card>> GetMostExpensiveCardsAsync()
//        {
//            return await _cardDAL.GetMostExpensiveCardsAsync();
//        }

//        public async Task<Result<User>> GetAllCardBuyersAsync()
//        {
//            return await _cardDAL.GetAllCardBuyersAsync();
//        }

//        public async Task<Result<Card>> GetCardsByQuantityAsync()
//        {
//            return await _cardDAL.GetCardsByQuantityAsync();
//        }

//        public async Task<Result<Card>> DeleteCardAsync(int cardId)
//        {
//            if (cardId <= 0)
//            {
//                return new Result<Card>
//                {
//                    Success = false,
//                    Message = "Invalid card id",
//                    Data = null
//                };
//            }

//            return await _cardDAL.DeleteCardAsync(cardId);
//        }

//        public async Task<Result<Card>> ProcessPaymentForUserAsync(int userId)
//        {
//            if (userId <= 0)
//            {
//                return new Result<Card>
//                {
//                    Success = false,
//                    Message = "Invalid user id",
//                    Data = null
//                };
//            }

//            return await _cardDAL.ProcessPaymentForUserAsync(userId);
//        }

//        public async Task<Result<Card>> GetCardsByUserAsync(int userId)
//        {
//            if (userId <= 0)
//            {
//                return new Result<Card>
//                {
//                    Success = false,
//                    Message = "Invalid user id",
//                    Data = null
//                };
//            }

//            return await _cardDAL.GetCardsByUserAsync(userId);
//        }

//        public async Task<Result<Card>> GetUnpaidCardsAsync(int userId)
//        {
//            if (userId <= 0)
//            {
//                return new Result<Card>
//                {
//                    Success = false,
//                    Message = "Invalid user id",
//                    Data = null
//                };
//            }

//            return await _cardDAL.GetUnpaidCardsAsync(userId);
//        }
    }
}
