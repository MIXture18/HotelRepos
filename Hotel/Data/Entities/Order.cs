using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int RoomId { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
