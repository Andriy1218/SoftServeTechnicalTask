using SoftServerTechnicalTask.Domain.BuildingBlocks;
using System.Collections.Generic;

namespace SoftServerTechnicalTask.Domain.Model
{
    public class Business : Entity
    {
        public int CountryId { get; private set; }
        public Country Country { get; private set; }
        public List<Family> Families { get; private set; }

        public Business(string name, int countryId)
        {
            Name = name;
            CountryId = countryId;
            Families = new List<Family>();
        }
    }
}
