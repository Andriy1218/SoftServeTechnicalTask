using System.Collections.Generic;
using Newtonsoft.Json;

namespace SoftServeTechnicalTask.Model
{
    public class Offering
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int FamilyId { get; set; }
        [JsonIgnore]
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
