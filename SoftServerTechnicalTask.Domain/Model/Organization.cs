using SoftServerTechnicalTask.Domain.BuildingBlocks;
using System.Collections.Generic;

namespace SoftServerTechnicalTask.Domain.Model
{
    public class Organization : Entity
    {
        public string Code { get; set; }

        public OrganizationType OrganizationType { get; set; }

        public string Owner { get; set; }

        public List<Country> Countries { get; private set; }

        public Organization(string name, string code, OrganizationType organizationType, string owner, int id = 0)
        {
            Name = name;
            Code = code;
            OrganizationType = organizationType;
            Owner = owner;
            Countries = new List<Country>();
            Id = id;
        }

        private Organization()
        {
            
        }
    }


    public enum OrganizationType
    {
        GeneralPartnership,
        LimitedPartnerships,
        LimitedLiabilityCompany,
        IncorporatedCompany,
        SocialEnterprise,
        Other
    }
}
