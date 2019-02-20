using SoftServerTechnicalTask.Domain.BuildingBlocks;

namespace SoftServerTechnicalTask.Domain.Model
{
    public class Department : Entity
    {
        public int OfferingId { get; private set; }
        public Offering Offering { get; private set; }

        public Department(string name, int offeringId)
        {
            Name = name;
            OfferingId = offeringId;
        }

    }
}
