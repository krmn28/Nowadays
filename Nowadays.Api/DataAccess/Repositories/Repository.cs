using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Nowadays.Api.Entities.Common;

namespace Nowadays.Api.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly NowadaysDbContext _context;

        public Repository(NowadaysDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Entity => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry entityEntry =  await Entity.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await Entity.AddRangeAsync(entities);
           
        }

        public async Task<bool> Delete(T entity)
        {
            return await Task.Run(()=> {
                    EntityEntry entityEntry =  Entity.Remove(entity);
                    return entityEntry.State == EntityState.Deleted;
            });
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter, bool tracking)
        {
            var queries = Entity.AsQueryable();
            if(!tracking)
                queries = queries.AsNoTracking();
            return await queries.FirstOrDefaultAsync(filter);
        }

        public IQueryable<T> GetAll(bool tracking)
        {
            var queries = Entity.AsQueryable();
            if(!tracking)
                queries = queries.AsNoTracking();
            return queries;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> filter, bool tracking)
        {
             var queries = Entity.Where(filter);
            if(!tracking)
                queries = queries.AsNoTracking();
            return queries;  
        }

        public async Task<bool> Update(T entity)
        {
            return await Task.Run(() => {
                EntityEntry entityEntry =  Entity.Update(entity);
                return entityEntry.State == EntityState.Modified;
            });
        }
    }
}