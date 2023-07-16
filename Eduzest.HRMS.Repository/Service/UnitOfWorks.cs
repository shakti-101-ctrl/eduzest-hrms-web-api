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

namespace Eduzest.HRMS.Repository.Service
{
    public class UnitOfWorks : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        //private readonly IGenericRepository<BranchDto> _branch;
        public UnitOfWorks(DataContext context,IMapper _mapper)
        {
            this._context = context;
            this._mapper = _mapper;
            Branches = new BranchRepository(_context,_mapper);
           
        }
        public IBranchRepository Branches { get; private set; }
        
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
