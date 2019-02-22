using Microsoft.EntityFrameworkCore;
using SoftServerTechnicalTask.Domain.BuildingBlocks;
using SoftServeTechnicalTask.Persistence.DBContext;
using System;
using System.Threading.Tasks;

namespace SoftServeTechnicalTask.Persistence.Repositories.BuildingBlocks
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        protected readonly ApplicationContext _context;

        protected GenericRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public virtual Task<TEntity> GetByIdAsync(int id)
        {
            return _context.FindAsync<TEntity>(id);
        }

        public virtual async Task<bool> CreateAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            var existingEntity = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (existingEntity == null)
                return false;

            _context.Update(existingEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> DeleteByIdAsync(int entityId)
        {
            var existingEntity = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == entityId);
            if (existingEntity == null)
                return false;

            _context.Remove(existingEntity);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
