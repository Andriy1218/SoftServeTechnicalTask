using SoftServerTechnicalTask.Domain.Abstractions;
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
    }
}
