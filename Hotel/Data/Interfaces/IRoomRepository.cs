using Hotel.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Data.Interfaces
{
    public interface IRoomRepository
    {
        public IEnumerable<Room> GetAllRooms();
        public Room FindRoomById(int roomId);
    }
}
