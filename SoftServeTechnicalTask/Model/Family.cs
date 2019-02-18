using System.Collections.Generic;
using Newtonsoft.Json;

namespace SoftServeTechnicalTask.Model
{
    public class Family
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int BusinessId { get; set; }
        [JsonIgnore]
        public Business Business { get; set; }

        public List<Offering> Offerings { get; }

        public Family(string name, int businessId)
        {
            Name = name;
            BusinessId = businessId;
            Offerings = new List<Offering>();
        }


    }
}
