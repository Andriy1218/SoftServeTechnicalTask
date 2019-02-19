using System.Threading.Tasks;
using SoftServerTechnicalTask.Domain.BuildingBlocks;
using SoftServerTechnicalTask.Domain.Model;

namespace SoftServerTechnicalTask.Domain.Abstractions
{
    // ToDo: Add other repositories
    public interface IOrganizationRepository : IGenericRepository<Organization>
    {
        Task<Organization> GetByName(string name);
    }
}
