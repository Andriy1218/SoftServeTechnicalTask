using SoftServerTechnicalTask.Domain.BuildingBlocks;

namespace SoftServerTechnicalTask.Domain.Model
{
    public class Department : ChildEntity
    {
        public Offering Offering { get; private set; }

        public Department(string name, int parentId)
        {
            Name = name;
            ParentId = parentId;
        }

        private Department()
        {
            
        }

    }
}
