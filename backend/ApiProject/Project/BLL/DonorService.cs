using AutoMapper;
using Project.BLL.Interfaces;
using Project.DAL.Interfaces;
using Project.Models;
using Project.Models.ModelsDTO;
using Project.Validators;
using System.Text.RegularExpressions;

namespace Project.BLL
{
    public class DonorService : IDonorService
    {
        IDonorDal _donorDAL;
        IMapper _mapper;
        public DonorService(IDonorDal donorDal, IMapper mapper)
        {
            _donorDAL = donorDal;
            _mapper = mapper;
        }

        //public async Task<Result<Donor>> AddDonorAsync(DonorDTO donorDTO)
        //{
        //    if(donorDTO != null && Validator.ValidateData(donorDTO.Name, donorDTO.Email, donorDTO.Phone) && await _donorDAL.existingEmail(donorDTO.Email) == false)
        //    {
        //        var donor = _mapper.Map<Donor>(donorDTO);
        //        return await _donorDAL.AddDonorAsync(donor);
        //    }
        //    return new Result<Donor>
        //    {
        //        Success = false,
        //        Message = "One or more detail wrong",
        //        Data = null
        //    };
        //}

        //public async Task<Result<Donor>> GetAllDonorsAsync()
        //{
        //    return await _donorDAL.GetAllDonorsAsync();
        //}


        //public async Task<Result<Donor>> GetDonorsByEmailAsync(string email)
        //{
        //    //if (Validator.ValidEmail(email))
        //        return await _donorDAL.GetDonorsByEmailAsync(email);
        //    //return new Result<Donor>
        //    //{
        //    //    Success = false,
        //    //    Message = "Invalid email",
        //    //    Data = null
        //    //};
        //}


        //public async Task<Result<Donor>> GetDonorsByNameAsync(string name)
        //{
        //    if (string.IsNullOrWhiteSpace(name))
        //    {
        //        return new Result<Donor>
        //        {
        //            Success = false,
        //            Message = "Invalid name",
        //            Data = null
        //        };
        //    }
        //    return await _donorDAL.GetDonorsByNameAsync(name);
        //}

        //public async Task<Result<Donor>> GetDonorsByPresentNameAsync(string presentName)
        //{
        //    if (string.IsNullOrWhiteSpace(presentName))
        //    {
        //        return new Result<Donor>
        //        {
        //            Success = false,
        //            Message = "Invalid present name",
        //            Data = null
        //        };
        //    }

        //    return await _donorDAL.GetDonorsByPresentNameAsync(presentName);
        //}


        //public async Task<Result<Donor>> RemoveDonorAsync(int id)
        //{
        //    if (id <= 0)
        //    {
        //        return new Result<Donor>
        //        {
        //            Success = false,
        //            Message = "Invalid donor id",
        //            Data = null
        //        };
        //    }

        //    return await _donorDAL.RemoveDonorAsync(id);
        //}

        //public async Task<Result<Donor>> UpdateDonorAsync(Donor donor)
        //{
        //    if (donor != null && Validator.ValidateData(donor.Name, donor.Email, donor.Phone))
        //    {
        //        return await _donorDAL.UpdateDonorAsync(donor);
        //    }
        //    return new Result<Donor> {
        //        Success = false,
        //        Message = "invalid dsetails",
        //        Data = null
        //    };
        //}
    }
}