using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoftServerTechnicalTask.Domain.Abstractions;
using SoftServerTechnicalTask.Domain.Abstractions.ChildEntityRepositories;
using SoftServerTechnicalTask.Domain.Model;
using SoftServeTechnicalTask.Persistence.DBContext;
using SoftServeTechnicalTask.Persistence.Repositories.BuildingBlocks;

namespace SoftServeTechnicalTask.Persistence.Repositories
{
    public class BusinessRepository : GenericChildRepository<Business>, IBusinessRepository
    {
        public BusinessRepository(ApplicationContext context) : base(context)
        {
        }

        public override Task<Business> GetByIdAsync(int id)
        {
            var existingEntity = _context.Set<Business>()
                .Include(x => x.Families)
                .ThenInclude(x => x.Offerings)
                .ThenInclude(x => x.Departments)
                .FirstOrDefaultAsync(x => x.Id == id);
            return existingEntity;
        }
    }
}
