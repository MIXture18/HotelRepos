using Hotel.Data.Entities;
using Hotel.Data.Interfaces;
using Hotel.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hotel.Controllers
{
    [Authorize(Roles = "reception")]
    public class ReceptionController : Controller
    {
        private readonly IReceptionRepository _repository;

        public ReceptionController(IReceptionRepository repository)
        {
            _repository = repository;
        }
        public IActionResult AllOrders()
        {
            return View(_repository.GetAllOrders());
        }

        public IActionResult AddRoom() => View();
        [HttpPost]
        public ActionResult AddRoom(AddRoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                var room = new Room
                {
                    Name = model.Name,
                    Desc = model.Desc,
                    Local = model.Floor,
                    Image = model.Image,
                    Floor = model.Floor,
                    Price = model.Price,
                    Available = true,
                    IsGived = false
                };
                _repository.AddRoom(room);
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult GivedRoom(int roomId)
        {
            _repository.GiveRoom(roomId);
            return RedirectToAction("AllOrders", "Reception");
        }
        public IActionResult TakeBackRoom(int roomId)
        {
            _repository.TakeBackRoom(roomId);
            return RedirectToAction("AllOrders", "Reception");
        }
        public IActionResult DeleteOrder(int orderId, int roomId)
        {
            _repository.DeleteOrder(orderId, roomId);
            return RedirectToAction("AllOrders", "Reception");
        }
    }
}

