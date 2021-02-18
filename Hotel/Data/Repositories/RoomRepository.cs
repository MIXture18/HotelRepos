using Hotel.Data.Entities;
using Hotel.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Data.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DBContext dbContext;
        public RoomRepository(DBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public Room FindRoomById(int roomId)
        {
            return dbContext.Rooms.Find(roomId);
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return dbContext.Rooms.OrderBy(i => i).ToList();
        }
    }
}
