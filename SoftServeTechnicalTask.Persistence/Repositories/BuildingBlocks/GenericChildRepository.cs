using Microsoft.EntityFrameworkCore;
using SoftServerTechnicalTask.Domain.BuildingBlocks;
using SoftServeTechnicalTask.Persistence.DBContext;
using System.Threading.Tasks;

namespace SoftServeTechnicalTask.Persistence.Repositories.BuildingBlocks
{
    public abstract class GenericChildRepository<TEntity> : GenericRepository<TEntity>
    where TEntity : ChildEntity
    {
        protected GenericChildRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<bool> CreateAsync(TEntity entity)
        {
            if (await _context.Set<TEntity>().AnyAsync(x => x.Name == entity.Name && x.ParentId == entity.ParentId))
                return false;

            return await base.CreateAsync(entity);
        }

        public Task<TEntity> GetByNameAndParentId(string name, int parentId)
        {
            return _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Name == name & x.ParentId == parentId);
        }
    }
}
