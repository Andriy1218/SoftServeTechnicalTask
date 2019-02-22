using System.Threading.Tasks;

namespace SoftServerTechnicalTask.Domain.BuildingBlocks
{
    public interface IGenericRepository<T>
    {
        Task<T> GetByIdAsync(int entityId);
        Task<bool> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteByIdAsync(int entityId);
    }
}
