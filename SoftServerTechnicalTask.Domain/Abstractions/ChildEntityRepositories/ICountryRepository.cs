using System.Threading.Tasks;
using SoftServerTechnicalTask.Domain.BuildingBlocks;
using SoftServerTechnicalTask.Domain.Model;

namespace SoftServerTechnicalTask.Domain.Abstractions.ChildEntityRepositories
{
    public interface ICountryRepository : IChildEntityRepository<Country>
    {
    }
}
