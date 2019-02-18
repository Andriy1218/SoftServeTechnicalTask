using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftServeTechnicalTask.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int OfferingId { get; set; }
        public Offering Offering { get; set; }

        public Department(string name, int offeringId)
        {
            Name = name;
            OfferingId = offeringId;
        }

    }
}
