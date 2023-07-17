using Eduzest.HRMS.Repository.DTO.Employee;
using Eduzest.HRMS.Repository.Interface;
using Eduzest.HRMS.Repository.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
namespace Eduzest.HRMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BranchController> _logger;
        public BranchController(IUnitOfWork unitOfWork, ILogger<BranchController> logger)
        {
            this._unitOfWork = unitOfWork;
            _logger = logger;

        }
        [HttpGet("getbranches")]
        public async Task<IActionResult> GetBranches()
        {
            try
            {
                _logger.LogInformation("getbranch executed");
                var result = await _unitOfWork.Branches.GetAllBranches();
                _unitOfWork.Dispose();
                
                return Ok(result);
            }
            catch (Exception ex)
            {

               
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getbranchbyid")]
        public async Task<IActionResult> GetBranchById(Guid branchid)
        {
            try
            {
                var result = await _unitOfWork.Branches.GetBranchById(branchid);
                _unitOfWork.Dispose();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("savebranch")]
        public async Task<IActionResult> SaveBranch(BranchDto branchDto)
        {
            try
            {
               
                var result = await _unitOfWork.Branches.AddBranch(branchDto);
                _unitOfWork.Dispose();
                return Ok(result);
            }
            catch (Exception ex)
            {
               
                return BadRequest(ex.Message);
            }     
        }
        [HttpPut("updatebranch")]
        public async Task<IActionResult> UpdateBranch(Guid branchid,BranchDto branchDto)
        {
            try
            {
                var result = await _unitOfWork.Branches.UpdateBranch(branchid,branchDto);
                _unitOfWork.Dispose();
                return Ok(result);
            }
            catch (Exception ex)
            {
             
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("deletebranch")]
        public async Task<IActionResult> DeleteBranch(Guid branchid)
        {
            try
            {
                var result = await _unitOfWork.Branches.DeleteBranch(branchid);
                _unitOfWork.Dispose();
                return Ok(result);
            }
            catch (Exception ex)
            {
               
                return BadRequest(ex.Message);
            }
        }

    }
}
