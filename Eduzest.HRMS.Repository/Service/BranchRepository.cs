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
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Diagnostics;
using Serilog.Core;

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
            
            _logger.LogInformation("***** BranchRepository -->AddBranch() started *****\n");
            ServiceResponse<BranchDto> serviceResponse = new ServiceResponse<BranchDto>();
            
            try
            {
                if(_dataContext !=null)
                {
                    _logger.LogInformation("branch -- >initialization started\n");
                    branch.BranchId = Guid.NewGuid();
                    branch.CreatedOn = DateTime.Now;
                    await _dataContext.Branches.AddAsync(_mapper.Map<Branch>(branch));
                    await _dataContext.SaveChangesAsync();
                    var data = _mapper.Map<BranchDto>(_dataContext.Branches.OrderByDescending(x=>x.CreatedOn).LastOrDefault());
                   
                    serviceResponse.Data = branch;
                    serviceResponse.Success = true;
                    serviceResponse.Response = (int)ResponseType.Ok;
                    serviceResponse.Message = MessaageType.Saved;
                    _logger.LogInformation("branch -- > record added successfully\n");
                }
            }
            catch (Exception ex)
            {
               
                serviceResponse.Message = MessaageType.FailureOnSave;
                serviceResponse.Success = true;
                serviceResponse.Response = (int)ResponseType.NoConnect;
               _logger.LogError(string.Format("[Message  : {0}] \n [Stack Trace : {1}] \n [Target Site : {2}]", ex.Message, ex.StackTrace, ex.TargetSite));

            }
            _logger.LogInformation("***** BranchRepository -- > AddBranch() completed *****\n");
            return serviceResponse;
        }

        public async Task<ServiceResponse<BranchDto>> DeleteBranch(Guid branchid)
        {
            _logger.LogInformation("***** BranchRepository -- >DeleteBranch() started *****\n");
            ServiceResponse<BranchDto> serviceResponse = new ServiceResponse<BranchDto>();

            var branch = await _dataContext.Branches.FindAsync(branchid);
            try
            {
                if (branch != null)
                {
                    _logger.LogInformation("branch -- >initialization started\n");
                    branch.IsActive = false;
                    branch.UpdatedOn = DateTime.Now;
                    _dataContext.Add(branch).State = EntityState.Modified;
                    await _dataContext.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<BranchDto>(branch);
                    serviceResponse.Message = MessaageType.Deleted;
                    serviceResponse.Success = true;
                    serviceResponse.Response = (int)ResponseType.Ok;
                    _logger.LogInformation("branch -- >deleted successfully\n");
                }
                else
                {
                    _logger.LogInformation("invalid branchid\n");
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
                _logger.LogError(string.Format("[Message  : {0}] \n [Stack Trace : {1}] \n [Target Site : {2}]", ex.Message, ex.StackTrace, ex.TargetSite));

            }
            _logger.LogInformation("***** BranchRepository -- > DeleteBranch() completed *****\n");
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<BranchDto>>> GetAllBranches()
        {
            _logger.LogInformation("***** BranchRepository-- >GetAllBranches() started *****\n");
            
            ServiceResponse<List<BranchDto>> serviceResponse = new ServiceResponse<List<BranchDto>>();
            var branches = await _dataContext.Branches.Where(x => x.IsActive == true).ToListAsync();
            try
            {
                if (branches.Count > 0)
                {
                    _logger.LogInformation("branches -- >data found\n");
                    serviceResponse.Data = _mapper.Map<List<BranchDto>>(branches);
                    serviceResponse.Message = MessaageType.RecordFound;
                    serviceResponse.Response = (int)ResponseType.Ok;
                    serviceResponse.Success = true;
                }
                else
                {
                    _logger.LogInformation("branches -- >no records\n");
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
                _logger.LogError(string.Format("[Message  : {0}] \n [Stack Trace : {1}] \n [Target Site : {2}]", ex.Message, ex.StackTrace, ex.TargetSite));

            }
            _logger.LogInformation("***** BranchRepository -- > GetAllBranches() completed*****\n");
            return serviceResponse;
        }

        public async Task<ServiceResponse<BranchDto>> GetBranchById(Guid branchid)
        {
            _logger.LogInformation("***** BranchRepository -- > GetBranchById() started *****\n");
            ServiceResponse<BranchDto> serviceResponse = new ServiceResponse<BranchDto>();
            try
            {
                
                var branch = await _dataContext.Branches.Where(x => x.BranchId == branchid && x.IsActive == true).FirstOrDefaultAsync();
                if (branch != null)
                {
                    _logger.LogInformation("branch -- > Branch found\n");
                    serviceResponse.Data = _mapper.Map<BranchDto>(branch);
                    serviceResponse.Message = MessaageType.RecordFound;
                    serviceResponse.Response = (int)ResponseType.Ok;
                    serviceResponse.Success = true;

                }
                else
                {
                    _logger.LogInformation("branch -- > Invalid BranchId\n");
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
                _logger.LogError(string.Format("[Message  : {0}] \n [Stack Trace : {1}] \n [Target Site : {2}]", ex.Message, ex.StackTrace, ex.TargetSite));
            }
            _logger.LogInformation("***** BranchRepository -- >GetBranchById() completed *****\n");
            return serviceResponse;
        }

        public async Task<ServiceResponse<BranchDto>> UpdateBranch(Guid branchid, BranchDto branch)
        {
            _logger.LogInformation("***** BranchRepository -- > UpdateBranch() started *****\n");
            ServiceResponse<BranchDto> serviceResponse = new ServiceResponse<BranchDto>();
            try
            {
                var brachDetails = await _dataContext.Branches.FindAsync(branchid);

                if (brachDetails != null)
                {
                    _logger.LogInformation("branch -- >initialization started\n");
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
                    _logger.LogInformation("branch -- >updated successfully\n");
                }
                else
                {
                    _logger.LogInformation("branch -- >invalid branchid\n");
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
                _logger.LogError(string.Format("[Message  : {0}] \n [Stack Trace : {1}] \n [Target Site : {2}]", ex.Message, ex.StackTrace, ex.TargetSite));
            }
            _logger.LogInformation("***** BranchRepository -- >UpdateBranch() completed ****\n");
            return serviceResponse;
        }
    }
}
