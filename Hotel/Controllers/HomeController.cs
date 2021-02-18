using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hotel.Models;
using Hotel.Data;
using Hotel.Data.Interfaces;

namespace Hotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRoomRepository _repository;

        public HomeController(IRoomRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.GetAllRooms());
        }

        public IActionResult RoomId(int roomId)
        {
            return View(_repository.FindRoomById(roomId));
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
