using Hotel.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Data.Interfaces
{
    public interface IOrderRepository
    {
        Task AddOrderAsync(string name, int bookId);
        IEnumerable<Split> GetOrderMyName(string name);
        Task DeleteOrderAsync(int orderId, int bookId);
        IEnumerable<Split> GetAllOrders();
        public bool CheckOrderMyName(string name);
    }
}
