using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json.Converters;

namespace SSTest2.Model
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public OrganizationType OrganizationType { get; set; }
        public string User { get; set; }

        public List<Country> Countries { get; set; }
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
