using System.Collections.Generic;

namespace SSTest2.Model
{
    public class Family
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public List<Offering> Offerings { get; set; }


    }
}
