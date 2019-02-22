using SoftServerTechnicalTask.Domain.BuildingBlocks;
using System.Collections.Generic;

namespace SoftServerTechnicalTask.Domain.Model
{
    public class Offering : ChildEntity
    {
        public Family Family { get; private set; }

        public List<Department> Departments { get; private set; }

        public Offering(string name, int familyId)
        {
            Name = name;
            ParentId = familyId;
            Departments = new List<Department>();
        }

        private Offering()
        {
            
        }
    }
}
