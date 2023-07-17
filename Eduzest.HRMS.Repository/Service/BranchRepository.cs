using AutoMapper;
using Eduzest.HRMS.DataAccess;
using Eduzest.HRMS.Entities.Entities.Employee;
using Eduzest.HRMS.Repository.DTO.Employee;
using Eduzest.HRMS.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Microsoft.Extensions.Logging;

namespace Eduzest.HRMS.Repository.Service
{
    public class BranchRepository :IBranchRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly ILogger<BranchRepository> _logger;
        public BranchRepository(DataContext context,IMapper _mapper, ILogger<BranchRepository> logger)
        {
            this._dataContext = context;
            this._mapper = _mapper;
           
            this._logger = logger;
        }

        public async Task<ServiceResponse<BranchDto>> AddBranch(BranchDto branch)
        {
            ServiceResponse<BranchDto> serviceResponse = new ServiceResponse<BranchDto>();

            try
            {
                if(_dataContext !=null)
                {
                    branch.BranchId = Guid.NewGuid();
                    branch.CreatedOn = DateTime.Now;
                    await _dataContext.Branches.AddAsync(_mapper.Map<Branch>(branch));
                    await _dataContext.SaveChangesAsync();
                    var data = _mapper.Map<BranchDto>(_dataContext.Branches.OrderByDescending(x=>x.CreatedOn).LastOrDefault());
                   
                    serviceResponse.Data = branch;
                    serviceResponse.Success = true;
                    serviceResponse.Response = (int)ResponseType.Ok;
                    serviceResponse.Message = MessaageType.Saved;
      
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Message = MessaageType.FailureOnSave;
                serviceResponse.Success = true;
                serviceResponse.Response = (int)ResponseType.NoConnect;
               
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<BranchDto>> DeleteBranch(Guid branchid)
        {
            ServiceResponse<BranchDto> serviceResponse = new ServiceResponse<BranchDto>();

            var branch = await _dataContext.Branches.FindAsync(branchid);
            try
            {
                if (branch != null)
                {
                    branch.IsActive = false;
                    branch.UpdatedOn = DateTime.Now;
                    _dataContext.Add(branch).State = EntityState.Modified;
                    await _dataContext.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<BranchDto>(branch);
                    serviceResponse.Message = MessaageType.Deleted;
                    serviceResponse.Success = true;
                    serviceResponse.Response = (int)ResponseType.Ok;
                }
                else
                {
                    serviceResponse.Message = MessaageType.DeletionFailed;
                    serviceResponse.Success = false;
                    serviceResponse.Response = (int)ResponseType.NoConnect;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Message = MessaageType.FailureOnException;
                serviceResponse.Success = false;
                serviceResponse.Response = (int)ResponseType.InternalServerError;
               
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<BranchDto>>> GetAllBranches()
        {
            _logger.LogInformation("Banda......");
            ServiceResponse<List<BranchDto>> serviceResponse = new ServiceResponse<List<BranchDto>>();
            var branches = await _dataContext.Branches.Where(x => x.IsActive == true).ToListAsync();
            try
            {
                if (branches.Count > 0)
                {
                    serviceResponse.Data = _mapper.Map<List<BranchDto>>(branches);
                    serviceResponse.Message = MessaageType.RecordFound;
                    serviceResponse.Response = (int)ResponseType.Ok;
                    serviceResponse.Success = true;
                }
                else
                {
                    serviceResponse.Message = MessaageType.NoRecordFound;
                    serviceResponse.Response = (int)ResponseType.NoConnect;
                    serviceResponse.Success = false;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Message = MessaageType.FailureOnException;
                serviceResponse.Success = false;
                serviceResponse.Response = (int)ResponseType.InternalServerError;
                
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<BranchDto>> GetBranchById(Guid branchid)
        {
            ServiceResponse<BranchDto> serviceResponse = new ServiceResponse<BranchDto>();
            var branch = await _dataContext.Branches.Where(x => x.BranchId == branchid && x.IsActive == true).FirstOrDefaultAsync();
            if (branch != null)
            {
                serviceResponse.Data = _mapper.Map<BranchDto>(branch);
                serviceResponse.Message = MessaageType.RecordFound;
                serviceResponse.Response = (int)ResponseType.Ok;
                serviceResponse.Success = true;

            }
            else
            {
                serviceResponse.Message = MessaageType.NoRecordFound;
                serviceResponse.Response = (int)ResponseType.NoConnect;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<BranchDto>> UpdateBranch(Guid branchid, BranchDto branch)
        {
            ServiceResponse<BranchDto> serviceResponse = new ServiceResponse<BranchDto>();
            try
            {
                var brachDetails = await _dataContext.Branches.FindAsync(branchid);

                if (brachDetails != null)
                {
                    brachDetails.BranchName = branch.BranchName;
                    brachDetails.Email = branch.Email;
                    brachDetails.MobileNumber = branch.MobileNumber;
                    brachDetails.City = branch.City;
                    brachDetails.State = branch.State;
                    brachDetails.Address = branch.Address;
                    brachDetails.UpdatedOn = branch.UpdatedOn;

                    _dataContext.Entry(brachDetails).State = EntityState.Modified;
                    await _dataContext.SaveChangesAsync();
                    serviceResponse.Data = _mapper.Map<BranchDto>(brachDetails);
                    serviceResponse.Message = MessaageType.Updated;
                    serviceResponse.Success = true;
                    serviceResponse.Response = (int)ResponseType.Ok;
                }
                else
                {
                    serviceResponse.Message = MessaageType.FailureOnUpdate;
                    serviceResponse.Success = false;
                    serviceResponse.Response = (int)ResponseType.NoConnect;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Message = MessaageType.FailureOnException;
                serviceResponse.Success = false;
                serviceResponse.Response = (int)ResponseType.InternalServerError;
               
            }
            return serviceResponse;
        }
    }
}
