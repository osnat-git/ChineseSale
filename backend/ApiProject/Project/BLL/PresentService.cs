using AutoMapper;
using Project.BLL.Interfaces;
using Project.DAL.Interfaces;
using Project.Models;
using Project.Models.ModelsDTO;
using Project.Validators;
using System.Threading.Tasks;

namespace Project.BLL
{
    public class PresentService : IPresentService
    {
        IPresentDal _presentDal;
        IMapper _mapper;
        public PresentService(IPresentDal presentDal, IMapper mapper)
        {
            _presentDal = presentDal;
            _mapper = mapper;
        }


        //public async Task<Result<Present>> AddPresentAsync(PresentDTO presentDTO)
        //{
        //    if (presentDTO == null)
        //    {
        //        return new Result<Present>
        //        {
        //            Success = false,
        //            Message = "Present data is null",
        //            Data = null
        //        };
        //    }

        //    if (!Validator.ValidName(presentDTO.Name) || presentDTO.Price <= 0 || presentDTO.Quantity < 0 || presentDTO.CategoryId <= 0 || presentDTO.DonorId <= 0)
        //    {
        //        return new Result<Present>
        //        {
        //            Success = false,
        //            Message = "Invalid present data",
        //            Data = null
        //        };
        //    }

        //    // Check for duplicate name
        //    var duplicateCheck = await _presentDAL.PresentNameExistsAsync(presentDTO.Name);
        //    if (duplicateCheck == null || duplicateCheck.Success == false)
        //    {
        //        return new Result<Present>
        //        {
        //            Success = false,
        //            Message = $"A present with name '{presentDTO.Name}' already exists",
        //            Data = null
        //        };
        //    }

        //    var present = _mapper.Map<Present>(presentDTO);
        //    return await _presentDAL.AddPresentAsync(present);
        //}

        //public async Task<Result<Present>> GetAllPresentsAsync()
        //{
        //    return await _presentDAL.GetAllPresentsAsync();
        //}

        //public async Task<Result<Present>> DeletePresentAsync(int presentId)
        //{
        //    if (presentId <= 0)
        //    {
        //        return new Result<Present>
        //        {
        //            Success = false,
        //            Message = "Invalid present id",
        //            Data = null
        //        };
        //    }

        //    return await _presentDAL.DeletePresentAsync(presentId);
        //}

        //public async Task<Result<Present>> UpdatePresentAsync(Present present)
        //{
        //    if (present == null || present.Id <= 0)
        //    {
        //        return new Result<Present>
        //        {
        //            Success = false,
        //            Message = "Invalid present",
        //            Data = null
        //        };
        //    }

        //    if (!Validator.ValidName(present.Name) || present.Price < 0 || present.Quantity < 0 || present.CategoryId <= 0 || present.DonorId <= 0)
        //    {
        //        return new Result<Present>
        //        {
        //            Success = false,
        //            Message = "Invalid present data",
        //            Data = null
        //        };
        //    }

        //    // Check for duplicate name (excluding current present)
        //    var duplicateCheck = await _presentDAL.PresentNameExistsAsync(present.Name, present.Id);
        //    if (duplicateCheck != null && duplicateCheck.Success  == true)
        //    {
        //        return new Result<Present>
        //        {
        //            Success = false,
        //            Message = $"A present with name '{present.Name}' already exists",
        //            Data = null
        //        };
        //    }

        //    return await _presentDAL.UpdatePresentAsync(present);
        //}

        //public async Task<Result<Present>> GetPresentsByNameAsync(string name)
        //{
        //    if (string.IsNullOrWhiteSpace(name))
        //    {
        //        return new Result<Present>
        //        {
        //            Success = false,
        //            Message = "Invalid name",
        //            Data = null
        //        };
        //    }

        //    return await _presentDAL.GetPresentsByNameAsync(name);
        //}

        //public async Task<Result<Present>> GetPresentsByDonorNameAsync(string donorName)
        //{
        //    if (string.IsNullOrWhiteSpace(donorName))
        //    {
        //        return new Result<Present>
        //        {
        //            Success = false,
        //            Message = "Invalid donor name",
        //            Data = null
        //        };
        //    }

        //    return await _presentDAL.GetPresentsByDonorNameAsync(donorName);
        //}

        //public async Task<Result<Present>> GetPresentsByBuyerCountAsync(int buyerCount)
        //{
        //    if (buyerCount < 0)
        //    {
        //        return new Result<Present>
        //        {
        //            Success = false,
        //            Message = "Invalid buyer count",
        //            Data = null
        //        };
        //    }

        //    return await _presentDAL.GetPresentsByBuyerCountAsync(buyerCount);
        //}
        //public async Task<Result<Present>> GetPresentsByPriceAsync()
        //{
        //    return await _presentDAL.GetPresentsByPriceAsync();
        //}
        //public async Task<Result<Present>> GetPresentsByCategoryAsync()
        //{
        //    return await _presentDAL.GetPresentsByCategoryAsync();
        //}

        //public async Task<Result<Present>> GetAllPresentsWithWinnersAsync()
        //{
        //    return await _presentDAL.GetAllPresentsWithWinnersAsync();
        //}
    }
}