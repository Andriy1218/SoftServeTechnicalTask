using SoftServerTechnicalTask.Domain.BuildingBlocks;
using System.Collections.Generic;

namespace SoftServerTechnicalTask.Domain.Model
{
    public class Business : ChildEntity
    {
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
