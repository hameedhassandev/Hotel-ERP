using Microsoft.AspNetCore.Mvc;
using MVC.Interfaces;

namespace MVC.Controllers
{
    public class ReportRoomsController : Controller
    {
        private readonly IRoomService _roomService;

        public ReportRoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public IActionResult Index()
        {
            var report = _roomService.ReportAllRooms();
            return View(report);
        }
    }
}
