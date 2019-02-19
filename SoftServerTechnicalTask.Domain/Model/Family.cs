using SoftServerTechnicalTask.Domain.BuildingBlocks;
using System.Collections.Generic;

namespace SoftServerTechnicalTask.Domain.Model
{
    public class Family : Entity
    {
        public string Name { get; set; }

        public int BusinessId { get; private set; }

        public Business Business { get; private set; }

        public List<Offering> Offerings { get; private set; }

        public Family(string name, int businessId)
        {
            Name = name;
            BusinessId = businessId;
            Offerings = new List<Offering>();
        }


    }
}
