using AutoMapper;
using Eduzest.HRMS.DataAccess;
using Eduzest.HRMS.Entities.Entities.Employee;
using Eduzest.HRMS.Repository.DTO.Employee;
using Eduzest.HRMS.Repository.Interface;
using Eduzest.HRMS.Repository.Service;
using Eduzest.HRMS.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Serilog;
namespace Eduzest.HRMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BranchController> _logger;
        private string ActionMethodName  = string.Empty;
        private string ControllerName = string.Empty;
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public BranchController(DataContext datacontext,IUnitOfWork unitOfWork,IMapper mapper, ILogger<BranchController> logger)
        {
            this._unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _dataContext = datacontext;
        }
        [HttpGet("getbranches")]
        public async Task<IActionResult> GetBranches()
        {
            try
            {
                return Ok(await _unitOfWork.Branches.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(new ServiceResponse<Branch>() { Message = MsgType.FailureOnException, Response = (int)ResType.InternalServerError });
            }         

        }

        [HttpGet("getbranchbyid")]
        public async Task<IActionResult> GetBranchById(Guid branchid)
        {
            var result = await _unitOfWork.Branches.GetItemById(branchid);
            if(result != null) 
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("postbranch")]
        public async Task<IActionResult> PostBranch(BranchDto branchDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    branchDto.BranchId = Guid.NewGuid();
                    //branchDto.CreatedOn = DateTime.Now;
                    var result = await _unitOfWork.Branches.Add(_mapper.Map<Branch>(branchDto));
                    _unitOfWork.Complete();
                    _unitOfWork.Dispose();
                    return Ok(result);
                }
                else
                {
                    return Ok(new ServiceResponse<Branch>() { Message = MsgType.FailureOnException, Response = (int)ResType.InternalServerError, Success = false });
                   
                }

            }
            catch(Exception ex)
            {
                return BadRequest(new ServiceResponse<Branch>() { Message = MsgType.FailureOnException, Response = (int)ResType.InternalServerError });
            }
               
        }
        [HttpPut("putbranch")]
        public async Task<IActionResult> PutBranch(BranchDto branchDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var branchDetails = await _dataContext.Branches.Where(branch => branch.BranchId == branchDto.BranchId).FirstOrDefaultAsync();
                    if(branchDetails!=null)
                    {
                        branchDetails.BranchName = branchDto.BranchName;
                        branchDetails.Email = branchDto.Email;
                        branchDetails.MobileNumber = branchDto.MobileNumber;
                        branchDetails.City = branchDto.City;
                        branchDetails.State = branchDto.State;
                        branchDetails.Address = branchDto.Address;
                        branchDetails.UpdatedBy = branchDto.UpdatedBy;
                        branchDetails.UpdatedOn = DateTime.Now;
                        var resullt = await _unitOfWork.Branches.Update(_mapper.Map<Branch>(branchDetails));
                        _unitOfWork.Complete();
                        _unitOfWork.Dispose();
                        return Ok(resullt);
                    }
                    else
                    {
                        return BadRequest(new ServiceResponse<Branch>() { Message = MsgType.FailureOnException, Response = (int)ResType.InternalServerError });
                    }
                   
                }
                else
                {
                    return BadRequest(new ServiceResponse<Branch>() { Message = MsgType.FailureOnException, Response = (int)ResType.InternalServerError });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new ServiceResponse<Branch>() { Message = MsgType.FailureOnException, Response = (int)ResType.InternalServerError });
            }    
        }
        [HttpDelete("deletebranch/{id}")]
        public async Task<IActionResult> DeleteBranch(Guid id)
        {
            try
            {
                var branch = await _dataContext.Branches.Where(x => x.BranchId == id).FirstOrDefaultAsync();
                if (branch != null)
                {
                    branch.IsActive = false;
                    var result = await _unitOfWork.Branches.Delete(id, branch);
                    _unitOfWork.Complete();
                    _unitOfWork.Dispose();
                    return Ok(result);
                }
                else
                {
                    return BadRequest(new ExceptionResponse() { Message = MsgType.FailureOnException, Response = (int)ResType.InternalServerError });
                }
            }
            catch(Exception ex)
            {
                return BadRequest(new ExceptionResponse() { Message = MsgType.FailureOnException, Response = (int)ResType.InternalServerError });
            }

        }

    }
}
