using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebUI.Constants;

namespace WebUI.Controllers
{
    public class VacancyController : Controller
    {
        private readonly IVacancyService vacancyService;
        public VacancyController(IVacancyService vacancyService)
        {
            this.vacancyService = vacancyService;
        }

        public IActionResult Index()
        {
            Header.Name = "Elan";

            var vacancies = vacancyService.GetWithCity();

            vacancies.Reverse();

            return View(vacancies);
        }
    }
}
