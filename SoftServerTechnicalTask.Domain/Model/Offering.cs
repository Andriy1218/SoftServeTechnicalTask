using SoftServerTechnicalTask.Domain.Abstractions;
using System.Collections.Generic;
using SoftServerTechnicalTask.Domain.BuildingBlocks;

namespace SoftServerTechnicalTask.Domain.Model
{
    public class Offering : Entity
    {
        public string Name { get; set; }

        public int FamilyId { get; private set; }

        public Family Family { get; private set; }

        public List<Department> Departments { get; private set; }

        public Offering(string name, int familyId)
        {
            Name = name;
            FamilyId = familyId;
            Departments = new List<Department>();
        }

    }
}
