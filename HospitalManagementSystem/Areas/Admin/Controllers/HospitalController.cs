using HospitalServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ViewModels;
using Utilities;
using HospitalModels;

namespace HospitalManagementSystem.Areas.Admin.Controllers
{
      [Area("Admin")]
    [Route("hosital")]
    public class HospitalController : Controller
    {
        private readonly IHospitalProp _hospital;
        public HospitalController(IHospitalProp hospital)
        {
            _hospital = hospital;
        }

        [Route("/")]
        public IActionResult Index(int pageNumber=1, int pageSize=10)
        {
            return View(_hospital.GetAll(pageNumber,pageSize));
        }

        [HttpGet]
        [Route("Edit")]
        public IActionResult Edit(Guid id) {
            HospitalViewModel model = _hospital.GetHospitalViewModel(id);
            return View(model);
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(HospitalViewModel model)
        {
            
             _hospital.UpdateHospital(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Add()
        {
            
            return View(new HospitalViewModel());

        }

        [HttpPost]
        [Route("create")]
        public IActionResult Add(HospitalViewModel model)
        {
            _hospital.InsertNewHospital(model);
            return RedirectToAction("Index");

        }

        [Route("Delete")]
        public IActionResult Delete(Guid id)
        {
            _hospital.DeleteHospitalView(id);
            return RedirectToAction("Index");   
        }


    }
}
