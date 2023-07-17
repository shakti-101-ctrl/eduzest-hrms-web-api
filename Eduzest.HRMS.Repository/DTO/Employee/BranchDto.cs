using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eduzest.HRMS.Entities.Base;
using Eduzest.HRMS.Repository.CommonUses;

namespace Eduzest.HRMS.Repository.DTO.Employee
{
    public class BranchDto : CommonProperties
    {
        public Guid? BranchId { get; set; }
        [Required]
        public string? BranchName { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Address { get; set; }
    }
}
