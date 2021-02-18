using Hotel.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Data.Interfaces
{
    public interface IReceptionRepository
    {
        public void AddRoom(Room room);
        public void GiveRoom(int roomId);
        public void TakeBackRoom(int roomId);
        public void DeleteOrder(int OrderId, int roomId);
        public IEnumerable<Split> GetAllOrders();
    }
}
