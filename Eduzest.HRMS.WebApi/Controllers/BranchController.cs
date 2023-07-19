using AutoMapper;
using Eduzest.HRMS.DataAccess;
using Eduzest.HRMS.Entities.Entities.Employee;
using Eduzest.HRMS.Repository.DTO.Employee;
using Eduzest.HRMS.Repository.Interface;
using Eduzest.HRMS.Repository.Service;
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
            var result = await _unitOfWork.Branches.GetAll();
            return Ok(result);
            
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
            branchDto.BranchId = Guid.NewGuid();
            branchDto.CreatedOn = DateTime.Now;

            var result = await _unitOfWork.Branches.Add(_mapper.Map<Branch>(branchDto));
            _unitOfWork.Complete();
            _unitOfWork.Dispose();
            return Ok(result);
           
        }
        [HttpPut("putbranch")]
        public async Task<IActionResult> PutBranch(Guid branchid, BranchDto branchDto)
        {
            var branchDetails = await _dataContext.Branches.Where(branch=>branch.BranchId==branchid).FirstOrDefaultAsync();
            if(branchDetails!=null)
            {
                branchDetails.BranchName = branchDto.BranchName;
                branchDetails.Email = branchDto.Email;
                branchDetails.MobileNumber = branchDto.MobileNumber;
                branchDetails.City = branchDto.City;
                branchDetails.State = branchDto.State;
                branchDetails.Address = branchDto.Address;
                branchDetails.UpdatedOn = branchDto.UpdatedOn;
                branchDetails.UpdatedBy = branchDto.UpdatedBy;
                branchDetails.UpdatedOn=DateTime.Now;   
                var resullt = await _unitOfWork.Branches.Update(branchid,_mapper.Map<Branch>(branchDetails));
                _unitOfWork.Complete();
                _unitOfWork.Dispose();
                return Ok(resullt);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("deletebranch")]
        public async Task<IActionResult> DeleteBranch(Guid branchid)
        {
            var branch =await _dataContext.Branches.Where(x=>x.BranchId == branchid).FirstOrDefaultAsync();
            if(branch!=null)
            {
                branch.IsActive = false;
                var result=await _unitOfWork.Branches.Delete(branchid,branch);
                _unitOfWork.Complete();
                _unitOfWork.Dispose();
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }

        }

    }
}
