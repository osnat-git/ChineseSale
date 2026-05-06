using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Interfaces;
using Project.DAL;
using Project.Models;
using Project.Models.ModelsDTO;

namespace Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DonorController : ControllerBase
    {
        IDonorService _donorService;
        public DonorController(IDonorService donorService)
        {
            _donorService = donorService;
        }


        //[Authorize(Roles = "Manager")]
        [HttpPost("/api/donor/addDonor")]
        public async Task<Result<Donor>> AddDonorAsync(DonorDTO donorDTO)
        {
            return await _donorService.AddDonorAsync(donorDTO);
        }

        //[Authorize(Roles = "Manager")]
        [HttpGet("/api/donor/getAllDonors")]
        public async Task<Result<Donor>> GetAllDonorsAsync()
        {
            return await _donorService.GetAllDonorsAsync();
        }

        //[Authorize(Roles = "Manager")]
        [HttpGet("/api/donor/getDonorsByEmail/{email}")]
        public async Task<Result<Donor>> GetDonorsByEmailAsync(string email)
        {
            return await _donorService.GetDonorsByEmailAsync(email);
        }

        //[Authorize(Roles = "Manager")]
        [HttpGet("/api/donor/getDonorsByName/{name}")]
        public async Task<Result<Donor>> GetDonorsByNameAsync(string name)
        {
            return await _donorService.GetDonorsByNameAsync(name);
        }

        //[Authorize(Roles = "Manager")]
        [HttpGet("/api/donor/getDonorsByPresent")]
        public async Task<Result<Donor>> GetDonorsByPresentNameAsync(string presentName)
        {
            return await _donorService.GetDonorsByPresentNameAsync(presentName);
        }


        //[Authorize(Roles = "Manager")]
        [HttpDelete("/api/donor/removeDonor/{id}")]
        public async Task<Result<Donor>> RemoveDonorAsync(int id)
        {
            return  await _donorService.RemoveDonorAsync(id);
        }

        //[Authorize(Roles = "Manager")]
        [HttpPut("/api/donor/updateDonor")]
        public async Task<Result<Donor>> UpdateDonorAsync(Donor donor)
        {
            return await _donorService.UpdateDonorAsync(donor);
        }
    }
}