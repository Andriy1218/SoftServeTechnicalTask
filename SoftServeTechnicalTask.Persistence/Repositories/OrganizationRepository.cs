using Microsoft.EntityFrameworkCore;
using SoftServerTechnicalTask.Domain.Abstractions;
using SoftServerTechnicalTask.Domain.Model;
using SoftServeTechnicalTask.Persistence.DBContext;
using System.Threading.Tasks;
using SoftServeTechnicalTask.Persistence.Repositories.BuildingBlocks;

namespace SoftServeTechnicalTask.Persistence.Repositories
{
    public class OrganizationRepository : GenericRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(ApplicationContext context) : base(context)
        {
        }

        public Task<Organization> GetByName(string name)
        {
            return _context.Organizations.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
