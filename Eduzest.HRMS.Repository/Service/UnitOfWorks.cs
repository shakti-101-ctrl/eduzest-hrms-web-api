using AutoMapper;
using Eduzest.HRMS.DataAccess;
using Eduzest.HRMS.Entities.Entities.Employee;
using Eduzest.HRMS.Repository.DTO.Employee;
using Eduzest.HRMS.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Microsoft.Extensions.Logging;

namespace Eduzest.HRMS.Repository.Service
{
    public class UnitOfWorks : IUnitOfWork
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        private readonly ILogger<BranchRepository> logger;
        public UnitOfWorks(DataContext _context,IMapper _mapper, ILogger<BranchRepository> _logger)
        {
            this.context = _context;
            this.mapper = _mapper;
            logger = _logger;
            
            Branches = new BranchRepository(context,mapper,logger);
           
        }
        public IBranchRepository Branches { get; private set; }
        
        public void Dispose()
        {
            context.Dispose();
        }

        public void Complete()
        {
            context.SaveChanges();
        }
    }
}
