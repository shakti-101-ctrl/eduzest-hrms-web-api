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
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
       // private readonly ILogger<Gene> _logger;
        public GenericRepository(DataContext context,IMapper mapper)

        {
            _dataContext= context;
            _mapper = mapper;
            //_logger = logger;
                  
        }
        public async Task<ServiceResponse<T>> Add(T entity)
        {
            ServiceResponse<T> serviceResponse = new ServiceResponse<T>();
            try
            {
                await _dataContext.Set<T>().AddAsync(_mapper.Map<T>(entity));
                serviceResponse.Data = entity;
                serviceResponse.Success = true;
                serviceResponse.Response = (int)ResponseType.Ok;
                serviceResponse.Message = MessaageType.Saved;
            }
            catch (Exception ex) {
                serviceResponse.Message = MessaageType.FailureOnSave;
                serviceResponse.Success = true;
                serviceResponse.Response = (int)ResponseType.NoConnect;
               // _logger.LogError(string.Format("[Message  : {0}] \n [Stack Trace : {1}] \n [Target Site : {2}]", ex.Message, ex.StackTrace, ex.TargetSite));
            }
            return serviceResponse;

        }
        public async Task<ServiceResponse<T>> Delete(Guid id, T entity)
        {
            ServiceResponse<T> serviceResponse = new ServiceResponse<T>();
            try
            {
                _dataContext.Set<T>().Attach(entity);
                _dataContext.Entry(entity).State = EntityState.Modified;
                serviceResponse.Data = _mapper.Map<T>(entity);
                serviceResponse.Message = MessaageType.Deleted;
                serviceResponse.Response = (int)ResponseType.Ok;
                serviceResponse.Success = true;
            }
            catch(Exception ex)
            {
                serviceResponse.Message = MessaageType.FailureOnSave;
                serviceResponse.Success = true;
                serviceResponse.Response = (int)ResponseType.NoConnect;
               // _logger.LogError(string.Format("[Message  : {0}] \n [Stack Trace : {1}] \n [Target Site : {2}]", ex.Message, ex.StackTrace, ex.TargetSite));
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<T>>> GetAll()
        {
            ServiceResponse<List<T>> serviceResponse = new ServiceResponse<List<T>>();
            try
            {
                var entities = _dataContext.Set<T>().AsNoTracking();
                serviceResponse.Data = _mapper.Map<List<T>>(entities.OrderByDescending(x=>x.CreatedOn).Where(x => x.IsActive == true));
                serviceResponse.Message = MessaageType.RecordFound;
                serviceResponse.Response = (int)ResponseType.Ok;
                serviceResponse.Success = true;
            }
            catch(Exception ex)
            {
                serviceResponse.Message = MessaageType.FailureOnSave;
                serviceResponse.Success = true;
                serviceResponse.Response = (int)ResponseType.NoConnect;
                //_logger.LogError(string.Format("[Message  : {0}] \n [Stack Trace : {1}] \n [Target Site : {2}]", ex.Message, ex.StackTrace, ex.TargetSite));
            } 
            return serviceResponse;
        }
        public async Task<ServiceResponse<T>> GetItemById(Guid id)
        {
            ServiceResponse<T> serviceResponse = new ServiceResponse<T>();
            try
            {
                T? entity = await _dataContext.Set<T>().FindAsync(id);
                serviceResponse.Data = _mapper.Map<T>(entity);
                serviceResponse.Message = MessaageType.RecordFound;
                serviceResponse.Response = (int)ResponseType.Ok;
                serviceResponse.Success = true;
            }
            catch(Exception ex)
            {
                serviceResponse.Message = MessaageType.FailureOnSave;
                serviceResponse.Success = true;
                serviceResponse.Response = (int)ResponseType.NoConnect;
              //  _logger.LogError(string.Format("[Message  : {0}] \n [Stack Trace : {1}] \n [Target Site : {2}]", ex.Message, ex.StackTrace, ex.TargetSite));
            }
           
            return serviceResponse;
        }

        public async Task<ServiceResponse<T>> Update(T entity)
        {
            ServiceResponse<T> serviceResponse = new ServiceResponse<T>();
            try
            {
                _dataContext.Set<T>().Attach(entity);
                _dataContext.Entry(entity).State = EntityState.Modified;
                serviceResponse.Data = _mapper.Map<T>(entity);
                serviceResponse.Message = MessaageType.Updated;
                serviceResponse.Response = (int)ResponseType.Ok;
                serviceResponse.Success = true;
            }
            catch(Exception ex)
            {
                serviceResponse.Message = MessaageType.FailureOnSave;
                serviceResponse.Success = true;
                serviceResponse.Response = (int)ResponseType.NoConnect;
               // _logger.LogError(string.Format("[Message  : {0}] \n [Stack Trace : {1}] \n [Target Site : {2}]", ex.Message, ex.StackTrace, ex.TargetSite));
            }
            
            return serviceResponse;
        }
    }
}

