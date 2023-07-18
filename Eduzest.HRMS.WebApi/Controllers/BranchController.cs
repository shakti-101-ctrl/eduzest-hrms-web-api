using Eduzest.HRMS.Repository.DTO.Employee;
using Eduzest.HRMS.Repository.Interface;
using Eduzest.HRMS.Repository.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Serilog;
namespace Eduzest.HRMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BranchController> _logger;
        private string Controllername = "BranchController";
        private string ActionMethodName  = string.Empty;
        private string ControllerName = string.Empty;
        
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
                _logger.LogInformation(string.Format("\n\t[Action method : {0},Status : Started,Controller : {1}]", ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName));
                var result = await _unitOfWork.Branches.GetAllBranches();
                _unitOfWork.Dispose();
                _logger.LogInformation(string.Format("\n\t[Action method : {0},Status : Completed,Controller : {1}]", ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName)); 
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception: ");
                _logger.LogError(string.Format("Error Details : \n[Action: {0},Contoller : {1}]  \n [Message  : {2}] \n [Stack Trace : {3}] \n [Target Site : {4}]", ActionMethodName,ControllerName,ex.Message,ex.StackTrace,ex.TargetSite));
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getbranchbyid")]
        public async Task<IActionResult> GetBranchById(Guid branchid)
        {
            try
            {
                _logger.LogInformation(string.Format("\n\t[Action method : {0},Status : Started,Controller : {1}]", ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName));
                var result = await _unitOfWork.Branches.GetBranchById(branchid);
                _unitOfWork.Dispose();
                _logger.LogInformation(string.Format("\n\t[Action method : {0},Status : Completed,Controller : {1}]", ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception: ");
                _logger.LogError(string.Format("Error Details : \n[Action: {0},Contoller : {1}]  \n [Message  : {2}] \n [Stack Trace : {3}] \n [Target Site : {4}]", ActionMethodName, ControllerName, ex.Message, ex.StackTrace, ex.TargetSite));
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("postbranch")]
        public async Task<IActionResult> PostBranch(BranchDto branchDto)
        {
            try
            {
                
                _logger.LogInformation(string.Format("\n[Action method : {0},Status : Started,Controller : {1}]", ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName));
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Error in model validations");
                    return UnprocessableEntity(ModelState);
                }
                var result = await _unitOfWork.Branches.AddBranch(branchDto);
                _logger.LogInformation(string.Format("\n[Action method : {0},Status : Completed,Controller : {1}]", ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName));
                _unitOfWork.Dispose();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception: ");
                _logger.LogError(string.Format("Error Details : \n[Action: {0},Contoller : {1}]  \n [Message  : {2}] \n [Stack Trace : {3}] \n [Target Site : {4}]", ActionMethodName, ControllerName, ex.Message, ex.StackTrace, ex.TargetSite));

                return BadRequest(ex.Message);
            }     
        }
        [HttpPut("putbranch")]
        public async Task<IActionResult> PutBranch(Guid branchid,BranchDto branchDto)
        {
            try
            {
                _logger.LogInformation(string.Format("\n[Action method : {0},Status : Started,Controller : {1}]", ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName));
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Error in model validations");
                    return UnprocessableEntity(ModelState);
                }
                var result = await _unitOfWork.Branches.UpdateBranch(branchid,branchDto);
                _logger.LogInformation(string.Format("\n\t[Action method : {0},Status : Completed,Controller : {1}]", ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName));
                _unitOfWork.Dispose();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception: ");
                _logger.LogError(string.Format("Error Details : \n[Action: {0},Contoller : {1}]  \n [Message  : {2}] \n [Stack Trace : {3}] \n [Target Site : {4}]", ActionMethodName, ControllerName, ex.Message, ex.StackTrace, ex.TargetSite));
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("deletebranch")]
        public async Task<IActionResult> DeleteBranch(Guid branchid)
        {
            try
            {
                _logger.LogInformation(string.Format("\n[Action method : {0},Status : Started,Controller : {1}]", ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName));
                var result = await _unitOfWork.Branches.DeleteBranch(branchid);
                _logger.LogInformation(string.Format("\n[Action method : {0},Status : Completed,Controller : {1}]", ControllerContext.ActionDescriptor.ActionName, ControllerContext.ActionDescriptor.ControllerName));
                _unitOfWork.Dispose();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception: ");
                _logger.LogError(string.Format("Error Details : \n[Action: {0},Contoller : {1}]  \n [Message  : {2}] \n [Stack Trace : {3}] \n [Target Site : {4}]", ActionMethodName, ControllerName, ex.Message, ex.StackTrace, ex.TargetSite));
                return BadRequest(ex.Message);
            }
        }

    }
}
