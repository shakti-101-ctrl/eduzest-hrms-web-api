using Eduzest.HRMS.Entities.Entities.Employee;
using Eduzest.HRMS.Repository.DTO.Employee;
using Eduzest.HRMS.Repository.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Repository.Interface
{
    public interface IBranchRepository
    {
        Task<ServiceResponse<List<BranchDto>>> GetAllBranches();
        Task<ServiceResponse<BranchDto>> AddBranch(BranchDto employee);
        Task<ServiceResponse<BranchDto>> UpdateBranch(Guid employeeId, BranchDto employee);
        Task<ServiceResponse<BranchDto>> DeleteBranch(Guid branchid);
        Task<ServiceResponse<BranchDto>> GetBranchById(Guid branchid);
    }
}
