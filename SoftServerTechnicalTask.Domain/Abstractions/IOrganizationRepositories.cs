namespace SoftServerTechnicalTask.Domain.Abstractions
{
    public interface IGenericRepositories<T>
    {
        T Get(int organizationId);
        void Create(T organization);
        void Update(T organization);
        void Delete(int organizationId);
    }
}
