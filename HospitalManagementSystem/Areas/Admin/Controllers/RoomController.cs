using HospitalServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace HospitalManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Room")]
    public class RoomController : Controller
    {

        private readonly IRoomProp _room;
        public RoomController(IRoomProp room)
        {
            _room = room;
        }

        [Route("rooms")]
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_room.GetAllRooms(pageNumber, pageSize));
        }

        [HttpGet]
        [Route("update")]
        public IActionResult Edit(Guid id)
        {
            RoomViewModel model = _room.GetRoom(id);
            return View(model);
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Edit(RoomViewModel model)
        {

            _room.UpdateRoom(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Add")]
        public IActionResult Add()
        {

            return View(new RoomViewModel());

        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(RoomViewModel model)
        {
            _room.AddRoom(model);
            return RedirectToAction("Index");

        }

        [Route("Delete")]
        public IActionResult Delete(Guid id)
        {
            _room.RemoveRoom(id);
            return RedirectToAction("Index");
        }
    }
}
