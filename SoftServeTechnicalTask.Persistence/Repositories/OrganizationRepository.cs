using Microsoft.EntityFrameworkCore;
using SoftServerTechnicalTask.Domain.Abstractions;
using SoftServerTechnicalTask.Domain.Model;
using SoftServeTechnicalTask.Persistence.DBContext;
using SoftServeTechnicalTask.Persistence.Repositories.BuildingBlocks;
using System.Threading.Tasks;

namespace SoftServeTechnicalTask.Persistence.Repositories
{
    public class OrganizationRepository : GenericRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(ApplicationContext context) : base(context)
        {
        }

        public override Task<Organization> GetByIdAsync(int id)
        {
            var existingEntity = _context.Set<Organization>()
                .Include(x => x.Countries)
                .ThenInclude(x => x.Businesses)
                .ThenInclude(x => x.Families)
                .ThenInclude(x => x.Offerings)
                .ThenInclude(x => x.Departments)
                .FirstOrDefaultAsync(x => x.Id == id);
            return existingEntity;
        }

        public override async Task<bool> CreateAsync(Organization entity)
        {
            if (await _context.Organizations.AnyAsync(x => x.Name == entity.Name))
                return false;

            return await base.CreateAsync(entity);
        }

        public override async Task<bool> UpdateAsync(Organization entity)
        {
            if (entity == null)
                return false;

            var existingEntity = await _context.Set<Organization>().FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (existingEntity == null)
                return false;

            existingEntity.Code = entity.Code;
            existingEntity.Owner = entity.Owner;
            existingEntity.OrganizationType = entity.OrganizationType;

            _context.Update(existingEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<Organization> GetByName(string name)
        {
            return _context.Organizations.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
