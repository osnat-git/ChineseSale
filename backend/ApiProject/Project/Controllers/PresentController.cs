using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Interfaces;
using Project.Models;
using Project.Models.ModelsDTO;

namespace Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PresentController : ControllerBase
    {
        IPresentService _presentService;
        public PresentController(IPresentService presentService)
        {
            _presentService = presentService;
        }

        //[Authorize(Roles = "Manager")]
        [HttpPost("/api/present/addPresent")]
        public async Task<Result<Present>> AddPresentAsync(PresentDTO presentDTO)
        {
            return await _presentService.AddPresentAsync(presentDTO);
        }
        // [Authorize(Roles = "Manager")]
        [HttpGet("/api/present/getAllPresent")]
        public async Task<Result<Present>> GetAllPresentsAsync()
        {
            return await _presentService.GetAllPresentsAsync();
        }

        [HttpGet("/api/present/getAllPresentsWithWinners")]
        public async Task<Result<Present>> GetAllPresentsWithWinnersAsync()
        {
            return await _presentService.GetAllPresentsWithWinnersAsync();
        }

        //[Authorize(Roles = "Manager")]
        [HttpDelete("/api/present/removePresent")]
        public async Task<Result<Present>> DeletePresentAsync(int presentId)
        {
            return await _presentService.DeletePresentAsync(presentId);
        }

        //[Authorize(Roles = "Manager")]
        [HttpPut("/api/present/updatePresent")]
        public async Task<Result<Present>> UpdatePresentAsync(Present present)
        {
            return await _presentService.UpdatePresentAsync(present);
        }

        //[Authorize(Roles = "Manager")]
        [HttpGet("/api/present/getPresentsByName")]
        public async Task<Result<Present>> GetPresentsByNameAsync(string name)
        {
            return await _presentService.GetPresentsByNameAsync(name);
        }

        //[Authorize(Roles = "Manager")]
        [HttpGet("/api/present/getPresentsByDonorName")]
        public async Task<Result<Present>> GetPresentsByDonorNameAsync(string donorName)
        {
            return await _presentService.GetPresentsByDonorNameAsync(donorName);
        }

        //[Authorize(Roles = "Manager")]
        [HttpGet("/api/present/getPresentsByBuyerCount")]
        public async Task<Result<Present>> GetPresentsByBuyerCountAsync(int buyerCount)
        {
            return await _presentService.GetPresentsByBuyerCountAsync(buyerCount);
        }

        [HttpGet("/api/present/getPresentsByPriceAsync")]
        public async Task<Result<Present>> GetPresentsByPriceAsync()
        {
            return await _presentService.GetPresentsByPriceAsync();
        }

        [HttpGet("/api/present/getPresentsByCategoryAsync")]
        public async Task<Result<Present>> GetPresentsByCategoryAsync()
        {
            return await _presentService.GetPresentsByCategoryAsync();
        }
    }
}