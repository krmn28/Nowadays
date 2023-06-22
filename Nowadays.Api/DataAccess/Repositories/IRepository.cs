using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nowadays.Api.Entities.Common;

namespace Nowadays.Api.DataAccess.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Entity { get; }
        Task<bool> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        IQueryable<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T, bool>> filter);
        Task<T> Get(Expression<Func<T, bool>> filter);
    }
}