using System.Collections.Generic;

namespace SoftServeTechnicalTask.Model
{
    public class Business
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public List<Family> Families { get; }

        public Business(string name, int countryId)
        {
            Name = name;
            CountryId = countryId;
            Families = new List<Family>();
        }

    }
}
