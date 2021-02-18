using Hotel.Data.Entities;
using Hotel.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Data.Repositories
{
    public class ReceptionRepository : IReceptionRepository
    {
        private readonly DBContext dbContext;
        public ReceptionRepository(DBContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void AddRoom(Room room)
        {
            dbContext.Rooms.Add(room);
            dbContext.SaveChanges();
        }

        public void GiveRoom(int roomId)
        {
            var room = dbContext.Rooms.Find(roomId);
            room.IsGived = true;
            dbContext.SaveChanges();
        }
        
        public void TakeBackRoom(int roomId)
        {
            var room = dbContext.Rooms.Find(roomId);
            room.IsGived = false;
            room.Available = true;
            dbContext.SaveChanges();
        }

        public IEnumerable<Split> GetAllOrders()
        {
            IEnumerable<Order> order = dbContext.Orders.ToList();
            IEnumerable<Room> room = dbContext.Rooms.ToList();
            var split = order
                .Join(room,
                c => c.RoomId,
                t => t.Id,
                (c, t) => new Split { order = c, room = t }
                );
            return split;
        }

        public void DeleteOrder(int orderid, int roomId)
        {
            var room = dbContext.Rooms.Find(roomId);
            room.Available = true;
            room.IsGived = false;
            Order order = dbContext.Orders.Find(orderid);
            dbContext.Orders.Remove(order);
            dbContext.SaveChanges();
        }
    }
}
