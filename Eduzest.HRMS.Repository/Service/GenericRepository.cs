using AutoMapper;
using Eduzest.HRMS.DataAccess;
using Eduzest.HRMS.Entities.Base;
using Eduzest.HRMS.Entities.Entities.Employee;
using Eduzest.HRMS.Repository.DTO.Employee;
using Eduzest.HRMS.Repository.Interface;
using Eduzest.HRMS.Repository.Specification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Repository.Service
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        
        public GenericRepository(DataContext context,IMapper mapper)
        {
            _dataContext= context;
            _mapper = mapper;
                  
        }
        public async Task<ServiceResponse<T>> Add(T entity)
        {
            ServiceResponse<T> serviceResponse = new ServiceResponse<T>();
            await _dataContext.Set<T>().AddAsync(_mapper.Map<T>(entity));
            serviceResponse.Data = entity;
            serviceResponse.Success = true;
            serviceResponse.Response = (int)ResponseType.Ok;
            serviceResponse.Message = MessaageType.Saved;
            return serviceResponse;

        }
        public async Task<ServiceResponse<T>> Delete(Guid id, T entity)
        {
            ServiceResponse<T> serviceResponse = new ServiceResponse<T>();
            _dataContext.Set<T>().Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
            serviceResponse.Data = _mapper.Map<T>(entity);
            serviceResponse.Message = MessaageType.Deleted;
            serviceResponse.Response = (int)ResponseType.Ok;
            serviceResponse.Success = true;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<T>>> GetAll()
        {
            ServiceResponse<List<T>> serviceResponse = new ServiceResponse<List<T>>();
            var entities = _dataContext.Set<T>().AsNoTracking();
            serviceResponse.Data = _mapper.Map<List<T>>(entities);
            serviceResponse.Message = MessaageType.RecordFound;
            serviceResponse.Response = (int)ResponseType.Ok;
            serviceResponse.Success = true;
            return serviceResponse;
        }
        public async Task<ServiceResponse<T>> GetItemById(Guid id)
        {
            ServiceResponse<T> serviceResponse = new ServiceResponse<T>();
            T? entity =await _dataContext.Set<T>().FindAsync(id);
            serviceResponse.Data = _mapper.Map<T>(entity);
            serviceResponse.Message = MessaageType.RecordFound;
            serviceResponse.Response = (int)ResponseType.Ok;
            serviceResponse.Success = true;
            return serviceResponse;
        }

        public async Task<ServiceResponse<T>> Update(Guid id, T entity)
        {
            ServiceResponse<T> serviceResponse = new ServiceResponse<T>();
            _dataContext.Set<T>().Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
            serviceResponse.Data = _mapper.Map<T>(entity);
            serviceResponse.Message = MessaageType.Updated;
            serviceResponse.Response = (int)ResponseType.Ok;
            serviceResponse.Success = true;
            return serviceResponse;
        }
    }
}

