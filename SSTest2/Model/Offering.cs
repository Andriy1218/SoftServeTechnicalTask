using System.Collections.Generic;

namespace SSTest2.Model
{
    public class Offering
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int FamilyId { get; set; }
        public Family Family { get; set; }

        public List<Department> Departments { get; }

        public Offering(string name, int familyId)
        {
            Name = name;
            FamilyId = familyId;
            Departments = new List<Department>();
        }

    }
}
