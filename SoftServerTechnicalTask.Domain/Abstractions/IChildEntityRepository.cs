using System.Threading.Tasks;
using SoftServerTechnicalTask.Domain.BuildingBlocks;

namespace SoftServerTechnicalTask.Domain.Abstractions
{
    public interface IChildEntityRepository<T> : IGenericRepository<T>
    {
        Task<T> GetByNameAndParentId(string name, int parentId);
    }
}
