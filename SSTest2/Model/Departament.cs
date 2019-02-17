using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSTest2.Model
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int ParentId { get; set; }

    }
}
