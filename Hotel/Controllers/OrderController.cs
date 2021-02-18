using Hotel.Data.Interfaces;
using Hotel.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Controllers
{
    public class OrderController : Controller
    {
        UserManager<User> _userManager;
        public IOrderRepository _repository;
        public OrderController(IOrderRepository repository, UserManager<User> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public async Task<ActionResult> Ordered(int roomId)
        {
            IdentityUser userName = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            bool check = _repository.CheckOrderMyName(userName.UserName);
            if (check)
            {
                await _repository.AddOrderAsync(userName.UserName, roomId);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["alert"] = "Клиент может забронировать только один номер!";
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> MyOrders()
        {
            IdentityUser userName = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var split = _repository.GetOrderMyName(userName.UserName);
            return View(split);
        }

        public async Task<ActionResult> DeleteOrder(int orderId, int roomId)
        {
            await _repository.DeleteOrderAsync(orderId, roomId);
            return RedirectToAction("MyOrders", "Order");
        }


    }
}
