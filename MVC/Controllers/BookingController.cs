using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Interfaces;

namespace MVC.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBrancheService _brancheService;
        private readonly IRoomService _roomService;

        public BookingController(IBrancheService brancheService, IRoomService roomService)
        {
            _brancheService = brancheService;
            _roomService = roomService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateBooking(int customerId)
        {
            var brancheSelectList = _brancheService.GetAllBranches();

            ViewData["BrancheId"] = new SelectList(brancheSelectList, "Id", "BrancheName");
            return View();
        }

        public IActionResult GetRooms(int brancheId)
        {
            var roomsSelectList = _roomService.GetAllRoomsByBrancheId(brancheId);
            return Ok(roomsSelectList);
        }
    }
}
