using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSTest2.Model
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public List<Business> Businesses { get; }

        public Country(string name, string code, int organizationId)
        {
            Name = name;
            Code = code;
            OrganizationId = organizationId;
            Businesses = new List<Business>();
        }

    }
}
