using System.Threading.Tasks;
using SoftServerTechnicalTask.Domain.BuildingBlocks;
using SoftServerTechnicalTask.Domain.Model;

namespace SoftServerTechnicalTask.Domain.Abstractions
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByNameIdentifier(int nameIdentifier);
    }
}
