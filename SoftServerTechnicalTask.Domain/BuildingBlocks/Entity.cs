namespace SoftServerTechnicalTask.Domain.BuildingBlocks
{
    public abstract class Entity
    {
        public int Id { get; private set; }
        public string Name { get; protected set; }
    }
}
