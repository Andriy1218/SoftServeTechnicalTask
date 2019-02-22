using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoftServerTechnicalTask.Domain.Abstractions.ChildEntityRepositories;
using SoftServerTechnicalTask.Domain.Model;
using SoftServeTechnicalTask.Persistence.DBContext;
using SoftServeTechnicalTask.Persistence.Repositories.BuildingBlocks;

namespace SoftServeTechnicalTask.Persistence.Repositories
{
    public class FamilyRepository : GenericChildRepository<Family>, IFamilyRepository
    {
        public FamilyRepository(ApplicationContext context) : base(context)
        {
        }

        public override Task<Family> GetByIdAsync(int id)
        {
            var existingEntity = _context.Set<Family>()
                .Include(x => x.Offerings)
                .ThenInclude(x => x.Departments)
                .FirstOrDefaultAsync(x => x.Id == id);
            return existingEntity;
        }
    }
}
