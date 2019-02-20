using SoftServerTechnicalTask.Domain.BuildingBlocks;
using System.Collections.Generic;

namespace SoftServerTechnicalTask.Domain.Model
{
    public class Country : Entity
    {
        public string Code { get; set; }
        public int OrganizationId { get; private set; }
        public Organization Organization { get; private set; }
        public List<Business> Businesses { get; private set; }

        public Country(string name, string code, int organizationId)
        {
            Name = name;
            Code = code;
            OrganizationId = organizationId;
            Businesses = new List<Business>();
        }

    }
}
