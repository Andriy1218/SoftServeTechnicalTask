using System.Threading.Tasks;
using SoftServerTechnicalTask.Domain.BuildingBlocks;
using SoftServerTechnicalTask.Domain.Model;

namespace SoftServerTechnicalTask.Domain.Abstractions
{
    public interface IOrganizationRepository : IGenericRepository<Organization>
    {
        Task<Organization> GetByName(string name);
    }
}
