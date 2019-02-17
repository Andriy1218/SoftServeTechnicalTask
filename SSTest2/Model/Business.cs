using System.Collections.Generic;

namespace SSTest2.Model
{
    public class Business
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Family> Families { get; set; }

    }
}
