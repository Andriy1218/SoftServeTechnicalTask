namespace SoftServerTechnicalTask.Domain.BuildingBlocks
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        public string Name { get; set; }
    }

    public abstract class ChildEntity : Entity
    {
       public int ParentId { get; set; }
    }
}
