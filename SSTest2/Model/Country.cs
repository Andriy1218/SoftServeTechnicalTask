using System.Collections.Generic;

namespace SSTest2.Model
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public int OrganizationId { get; set; }

        //public List<Business> Businesses { get; set; }

    }
}
