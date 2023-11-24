using HospitalServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace HospitalManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Contact")]
    public class ContactController : Controller
    {
        private readonly IContacts _contact;
        public ContactController(IContacts contact)
        {
            _contact = contact;
        }

        [Route("contacts")]
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_contact.GetAllContacts(pageNumber, pageSize));
        }

        [HttpGet]
        [Route("update")]
        public IActionResult Edit(Guid id)
        {
            ContactViewModel model = _contact.GetContact(id);
            return View(model);
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Edit(ContactViewModel model)
        {

            _contact.UpdateContact(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Add")]
        public IActionResult Add()
        {

            return View(new ContactViewModel());

        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(ContactViewModel model)
        {
            _contact.AddContact(model);
            return RedirectToAction("Index");

        }

        [Route("Delete")]
        public IActionResult Delete(Guid id)
        {
            _contact.RemoveContact(id);
            return RedirectToAction("Index");
        }
    }
}
