using Microsoft.EntityFrameworkCore;
using SoftServerTechnicalTask.Domain.BuildingBlocks;
using SoftServeTechnicalTask.Persistence.DBContext;
using System;
using System.Threading.Tasks;

namespace SoftServeTechnicalTask.Persistence.Repositories.BuildingBlocks
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : Entity
    {
        protected readonly ApplicationContext _context;

        public GenericRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            return _context.FindAsync<TEntity>(id);
        }

        public async Task<bool> CreateAsync(TEntity entity)
        {
            if (await Has(entity.Id))
                return false;

            var entry = await _context.AddAsync(entity);
            return true;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            var existingEntity = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (existingEntity == null)
                return false;

            _context.Update(entity);
            return true;
        }

        public async Task<bool> DeleteByIdAsync(int entityId)
        {
            var existingEntity = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == entityId);
            if (existingEntity == null)
                return false;

            _context.Remove(existingEntity);
            return true;
        }

        public Task<bool> Has(int entityId)
        {
            return _context.Set<TEntity>().AnyAsync(x => x.Id == entityId);
        }
    }
}
