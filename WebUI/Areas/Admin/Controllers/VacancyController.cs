using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    public class VacancyController : Controller
    {
        private readonly IVacancyService vacancyService;
        public VacancyController(IVacancyService vacancyService)
        {
            this.vacancyService = vacancyService;
        }

        public IActionResult Index()
        {
            var vacancies = vacancyService.GetWithCity().ToPagedList(1, 20);

            return View(vacancies);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var value = vacancyService.GetById(id);

            vacancyService.Delete(value);

            return RedirectToAction("index");
        }
    }
}
