using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Data.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Local { get; set; }
        public int Floor { get; set; }
        public int Price { get; set; }
        public bool Available { get; set; }
        public bool IsGived { get; set; }

    }
}
