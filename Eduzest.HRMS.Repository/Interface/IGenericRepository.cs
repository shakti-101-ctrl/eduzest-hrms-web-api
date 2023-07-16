using Eduzest.HRMS.Entities.Base;
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
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();
     
        void Add(T enitity);
        Task AddAsync(T enitity, string userId);
        void Update(T entity);
        Task UpdateAsync(T entity, string userId);
        void Delete(T entity);
        Task DeleteAsync(T entity, string userId);
        void AddRange(IEnumerable<T> entity);
        Task AddRangeAsync(IEnumerable<T> entities, string userId);
        void UpdateRange(IEnumerable<T> entity);
        void RemoveRange(IEnumerable<T> entity);
        
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        Task<IQueryable<T>> Query(Expression<Func<T, bool>> predicate);
        Task<IList<T>> GetListItems(Expression<Func<T, bool>> predicate, params string[] navigationProperties);
        Task<T> GetSingleItemsAsync(Expression<Func<T, bool>> predicate, params string[] navigationProperties);
        T GetSingleItems(Expression<Func<T, bool>> predicate, params string[] navigationProperties);
    }
}
