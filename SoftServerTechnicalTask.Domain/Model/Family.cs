using System.Collections.Generic;

namespace SoftServerTechnicalTask.Domain.Model
{
    public class Family
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BusinessId { get; set; }
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
