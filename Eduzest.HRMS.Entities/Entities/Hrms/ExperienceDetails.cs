﻿using Eduzest.HRMS.Entities.Base;
using Eduzest.HRMS.Entities.Entities.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Entities.Entities.Hrms
{
    //[Table("ExperienceDetails")]
    public class ExperienceDetails : BaseEntity
    {
        [Key]
        [Column("experienceid")]
        public Guid? ExperienceId { get; set; }

        [Column("empcode")]
        public EmployeeDetails? EmpCode { get; set; }

        [Column("fromdate")]
        public DateTime? FromDate { get; set; }

        [Column("todate")]
        public DateTime? ToDate { get; set; }

       
        [Column("authorizedby")]
        public DateTime? AuthorizedBy { get; set; }

    }
}
