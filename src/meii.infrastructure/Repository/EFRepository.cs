using meii.Business.Interfaces;
using meii.infrastrutucture.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace meii.infrastructure.Repository
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly MEContext _context;
        protected readonly DbSet<TEntity> DbSet;

        public EFRepository(MEContext context)
        {
            _context = context;
            DbSet = context.Set<TEntity>();
        }
        public async Task Add(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetId(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task Remove(TEntity entity)
        {
            _context.Remove(entity);
            await SaveChangesAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            _context.Update(entity);
            await SaveChangesAsync();
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}
