using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.Models;
using X.PagedList;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CityController : Controller
    {
        private readonly ICityService cityService;
        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        public IActionResult Index()
        {
            var cities = cityService.GetAll().ToPagedList(1, 20);

            return View(cities);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CityModel model)
        {
            if (ModelState.IsValid)
            {
                City city = new()
                {
                    Name = model.Name,
                };
                cityService.Add(city);
                return RedirectPermanent("/admin/city/index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            cityService.Delete(id: id);

            return RedirectPermanent("/admin/city/index");

        }
    }
}
