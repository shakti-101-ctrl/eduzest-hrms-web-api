using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eduzest.HRMS.Entities.Base;

namespace Eduzest.HRMS.Repository.DTO.Employee
{
    public class BranchDto : BaseEntity
    {
        public Guid? BranchId { get; set; }
        public string? BranchName { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Address { get; set; }
    }
}
