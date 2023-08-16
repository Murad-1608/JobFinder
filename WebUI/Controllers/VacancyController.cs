using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebUI.Constants;
using WebUI.Models;
using WebUI.Models.ViewModels;

namespace WebUI.Controllers
{
    public class VacancyController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IVacancyService vacancyService;
        private readonly ICityService cityService;
        private readonly IEducationService educationService;
        private readonly IExperienceService experienceService;
        public VacancyController(ICategoryService categoryService, ICityService cityService,
                                 IEducationService educationService,
                                 IExperienceService experienceService, IVacancyService vacancyService)
        {
            this.categoryService = categoryService;
            this.cityService = cityService;
            this.educationService = educationService;
            this.experienceService = experienceService;
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

        public IActionResult Add()
        {
            Header.Name = "Yeni elan";

            VacancyViewModel viewModel = ViewModel(new AddVacancyModel());

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(VacancyViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Vacancy vacancy = new()
                {
                    CategoryId = viewModel.AddVacancyModel.CategoryId,
                    CityId = viewModel.AddVacancyModel.CityId,
                    ExperienceId = viewModel.AddVacancyModel.ExperienceId,
                    EducationId = viewModel.AddVacancyModel.EducationId,
                    Email = viewModel.AddVacancyModel.Email,
                    PhoneNumber = viewModel.AddVacancyModel.PhoneNumber,
                    Position = viewModel.AddVacancyModel.Position,
                    Company = viewModel.AddVacancyModel.Company,
                    Age = viewModel.AddVacancyModel.Age,
                    Salary = viewModel.AddVacancyModel.Salary,
                    Requirements = viewModel.AddVacancyModel.Requirements,
                    JobInformation = viewModel.AddVacancyModel.JobInformation,
                    IsActive = false,
                    IsPremium = false,
                    CreateDate = DateTime.Now,
                    EndDate = viewModel.AddVacancyModel.EndDate,
                };
                vacancyService.Add(vacancy);
                return RedirectToAction("index");
            }
            viewModel = ViewModel(viewModel.AddVacancyModel);

            return View(viewModel);
        }



        private VacancyViewModel ViewModel(AddVacancyModel model)
        {
            List<SelectListItem> categories = (from i in categoryService.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = i.Name,
                                                   Value = i.Id.ToString()
                                               }).ToList();

            List<SelectListItem> experiences = (from i in experienceService.GetAll()
                                                select new SelectListItem
                                                {
                                                    Text = i.Name,
                                                    Value = i.Id.ToString()
                                                }).ToList();


            List<SelectListItem> city = (from i in cityService.GetAll()
                                         select new SelectListItem
                                         {
                                             Text = i.Name,
                                             Value = i.Id.ToString()
                                         }).ToList();

            List<SelectListItem> education = (from i in educationService.GetAll()
                                              select new SelectListItem
                                              {
                                                  Text = i.Name,
                                                  Value = i.Id.ToString()
                                              }).ToList();



            VacancyViewModel viewmodel = new()
            {
                Categories = categories,
                Experiences = experiences,
                Cities = city,
                Educations = education,
                AddVacancyModel = model
            };

            return viewmodel;
        }
    }
}
