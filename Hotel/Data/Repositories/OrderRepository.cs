using Hotel.Data.Entities;
using Hotel.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Data.Repositories
{
    [Authorize(Roles = "reception")]
    public class OrderRepository : IOrderRepository
    {
        private readonly DBContext appDBContent;

        public OrderRepository(DBContext appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Split> GetOrderMyName(string name)
        {
            IEnumerable<Order> order = appDBContent.Orders.Where(c => c.ClientName == name).ToList();
            IEnumerable<Room> room = appDBContent.Rooms.ToList();
            var split = order
                .Join(room,
                c => c.RoomId,
                t => t.Id,
                (c, t) => new Split { order = c, room = t }
                );
            return split;
        }
        
        public bool CheckOrderMyName(string name)
        {

            IEnumerable<Order> order = appDBContent.Orders.Where(c => c.ClientName == name).ToList();
            if (order.Count()<1){return true;}
            else return false;
        }

        public async Task AddOrderAsync(string name, int roomId)
        {
            var user = await appDBContent.Users.FirstOrDefaultAsync(c => c.UserName == name);

            var item = new Order()
            {
                ClientName = user.UserName,
                Phone = user.PhoneNumber,
                Email = user.Email,
                RoomId = roomId,
                OrderTime = DateTime.Now
            };
            var room = await appDBContent.Rooms.FindAsync(roomId);
            room.Available = false;
            await appDBContent.Orders.AddAsync(item);
            await appDBContent.SaveChangesAsync();
        }
        public async Task DeleteOrderAsync(int orderid, int roomId)
        {
            var room = await appDBContent.Rooms.FindAsync(roomId);
            room.Available = true;
            Order order = await appDBContent.Orders.FindAsync(orderid);
            appDBContent.Orders.Remove(order);
            appDBContent.SaveChanges();
        }

        public IEnumerable<Split> GetAllOrders()
        {
            IEnumerable<Order> order = appDBContent.Orders.ToList();
            IEnumerable<Room> room = appDBContent.Rooms.ToList();
            var split = order
                .Join(room,
                c => c.RoomId,
                t => t.Id,
                (c, t) => new Split { order = c, room = t }
                );
            return split;
        }
    }
}
