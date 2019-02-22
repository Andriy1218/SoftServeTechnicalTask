using SoftServerTechnicalTask.Domain.BuildingBlocks;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SoftServerTechnicalTask.Domain.Model
{
    public class Business : ChildEntity
    {
        [IgnoreDataMember]
        public Country Country { get; private set; }
        public List<Family> Families { get; private set; }

        public Business(string name, int parentId)
        {
            Name = name;
            ParentId = parentId;
            Families = new List<Family>();
        }

        private Business()
        {
            
        }
    }
}
