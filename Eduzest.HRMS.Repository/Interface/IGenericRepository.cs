using Eduzest.HRMS.Entities.Base;
using Eduzest.HRMS.Repository.DTO.Employee;
using Eduzest.HRMS.Repository.Service;
using Eduzest.HRMS.Repository.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Repository.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<ServiceResponse<List<T>>> GetAll();
        Task<ServiceResponse<T>> Add(T entity);
        Task<ServiceResponse<T>> Update(T entity);
        Task<ServiceResponse<T>> Delete(Guid id,T entity);
        Task<ServiceResponse<T>> GetItemById(Guid id);
    }
}
