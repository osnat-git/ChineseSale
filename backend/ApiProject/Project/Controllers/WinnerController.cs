using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Interfaces;
using Project.Models;
using Project.Models.ModelsDTO;

namespace Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WinnerController : ControllerBase
    {
        IWinnerService _randomService;
        public WinnerController(IWinnerService randomService)
        {
            _randomService = randomService;
        }

        //[Authorize(Roles = "Manager")]
        [HttpPost("/api/winner/addWinner")]
        public async Task<Result<Winner>> DrawWinnerForPresentAsync(int presentId)
        {
            return await _randomService.DrawWinnerForPresentAsync(presentId);
        }

        //[Authorize(Roles = "Manager")]
        [HttpGet("/api/winner/getPresentsWithUsers")]
        public async Task<Result<Dictionary<Present, List<User>>>> GetPresentsWithUsersAsync()
        {
            return await _randomService.GetPresentsWithUsersAsync();
        }

        //[Authorize(Roles = "Manager")]
        [HttpGet("/api/winner/getReportTotalIncome")]
        public async Task<decimal> CalculateTotalIncomeForPresentAsync()
        {
            return await _randomService.CalculateTotalIncomeForPresentAsync();
        }

        //[Authorize(Roles = "Manager")]
        [HttpGet("/api/winner/sendWinnerEmailAsync")]
        public async Task<Result<string>> SendWinnerEmailAsync()
        {
            return await _randomService.SendWinnerEmailAsync();
        }
    }
}