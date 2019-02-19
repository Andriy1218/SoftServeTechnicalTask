using System.Collections.Generic;

namespace SoftServerTechnicalTask.Domain.Model
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public OrganizationType OrganizationType { get; set; }
        public string Owner { get; set; }

        public List<Country> Countries { get; private set; }

        public Organization(string name, string code, OrganizationType organizationType, string owner)
        {
            Name = name;
            Code = code;
            OrganizationType = organizationType;
            Owner = owner;
            Countries = new List<Country>();
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
