using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Data.Entities
{
    public class Split
    {
        public Room room { get; set; }
        public Order order { get; set; }
    }
}
