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

        public IActionResult Search(int cityId, int categoryId, int educationId, int experienceId, string search)
        {
            var vacancies = vacancyService.Filter(cityId, categoryId, educationId, experienceId, search);

            return View(vacancies);
        }

        public IActionResult Details(int id)
        {
            var vacancy = vacancyService.Details(id);

            return View(vacancy);
        }
    }
}
