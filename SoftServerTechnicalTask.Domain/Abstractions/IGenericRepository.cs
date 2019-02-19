using System.Threading.Tasks;

namespace SoftServerTechnicalTask.Domain.Abstractions
{
    public interface IGenericRepository<T>
    {
        Task<T> GetById(int entityId);
        Task<bool> Create(T entity);
        Task Update(T entity);
        Task<bool> DeleteById(int entityId);
    }
}
