using Eduzest.HRMS.DataAccess;
using Eduzest.HRMS.Entities.Base;
using Eduzest.HRMS.Repository.Interface;
using Eduzest.HRMS.Repository.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Eduzest.HRMS.Repository.Service
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;
        public GenericRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }
        
       
        public void Add(T enitity)
        {
            _context.Set<T>().Add(enitity);
            // _context.SaveChanges();
        }
        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            // _context.SaveChanges();

        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            // _context.SaveChanges();
        }
        public async Task AddAsync(T entity, string userId)
        {
            await _context.Set<T>().AddAsync(entity);
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity, string userId)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            //    await _context.SaveChangesAsync(userId);
        }
        public async Task DeleteAsync(T entity, string userId)
        {
            _context.Set<T>().Remove(entity);
            _context.Entry(entity).State = EntityState.Deleted;
            //    await _context.SaveChangesAsync(userId);
        }
       
        public void AddRange(IEnumerable<T> entity)
        {
            _context.Set<T>().AddRange(entity);
        }
        public async Task AddRangeAsync(IEnumerable<T> entities, string userId)
        {
            _context.Set<T>().AddRange(entities);
            _context.Entry(entities).State = EntityState.Added;
            await _context.AddRangeAsync(userId);
        }
        public void UpdateRange(IEnumerable<T> entity)
        {
            _context.Set<T>().UpdateRange(entity);
        }
        public void RemoveRange(IEnumerable<T> entity)
        {
            _context.Set<T>().RemoveRange(entity);
        }
        
       
        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).CountAsync();
        }
        
        public async Task<IQueryable<T>> Query(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }
        public async Task<IList<T>> GetListItems(Expression<Func<T, bool>> predicate, params string[] navigationProperties)
        {
            List<T> list;
            // using (var ctx = new _context())
            // {
            var query = _context.Set<T>().AsQueryable();
            foreach (string navigationProperty in navigationProperties)
                query = query.Include(navigationProperty);//got to reaffect it.
            list = query.Where(predicate).ToList<T>();
            //}
            return list;
        }
        public async Task<T> GetSingleItemsAsync(Expression<Func<T, bool>> predicate, params string[] navigationProperties)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (string navigationProperty in navigationProperties)
                query = query.Include(navigationProperty);//got to reaffect it.
            return await query.FirstOrDefaultAsync(predicate);
        }
        public T GetSingleItems(Expression<Func<T, bool>> predicate, params string[] navigationProperties)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (string navigationProperty in navigationProperties)
                query = query.Include(navigationProperty);//got to reaffect it.
            return query.FirstOrDefault(predicate);
        }
       
    }
}

