using System.Runtime.Serialization;
using SoftServerTechnicalTask.Domain.BuildingBlocks;

namespace SoftServerTechnicalTask.Domain.Model
{
    public class Department : ChildEntity
    {
        [IgnoreDataMember]
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
