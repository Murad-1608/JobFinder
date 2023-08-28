using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebUI.Areas.Admin.Models;
using WebUI.Areas.Admin.Models.ViewModels;
using X.PagedList;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("admin")]
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
            ViewBag.NumberOfFalseVacancies = vacancyService.GetWithCityIsFalse().Count;

            var vacancies = vacancyService.GetWithCityIsActive().ToPagedList(1, 20);

            return View(vacancies);
        }
        public IActionResult NewVacancy()
        {
            var vacancies = vacancyService.GetWithCityIsFalse().ToPagedList(1, 20);

            return View(vacancies);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var value = vacancyService.GetById(id);

            vacancyService.Delete(value);

            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            VacancyViewModel vacancyViewModel = new VacancyViewModel();
            vacancyViewModel = ViewModel(new VacancyModel());

            return View(vacancyViewModel);
        }

        [HttpPost]
        public IActionResult Add(VacancyViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Vacancy vacancy = new()
                {
                    CategoryId = viewModel.VacancyModel.CategoryId,
                    CityId = viewModel.VacancyModel.CityId,
                    ExperienceId = viewModel.VacancyModel.ExperienceId,
                    EducationId = viewModel.VacancyModel.EducationId,
                    Email = viewModel.VacancyModel.Email,
                    PhoneNumber = viewModel.VacancyModel.PhoneNumber,
                    Position = viewModel.VacancyModel.Position,
                    Company = viewModel.VacancyModel.Company,
                    Age = viewModel.VacancyModel.Age,
                    Salary = viewModel.VacancyModel.Salary,
                    Requirements = viewModel.VacancyModel.Requirements,
                    JobInformation = viewModel.VacancyModel.JobInformation,
                    IsActive = true,
                    IsPremium = false,
                    CreateDate = DateTime.Now,
                    EndDate = viewModel.VacancyModel.EndDate,
                };
                vacancyService.Add(vacancy);
                return RedirectToAction("index");
            }
            viewModel = ViewModel(viewModel.VacancyModel);

            return View(viewModel);
        }

        public IActionResult Update(int id)
        {
            var vacancy = vacancyService.Details(id: id);

            VacancyModel viewModel = new VacancyModel()
            {
                Age = vacancy.Age,
                Salary = vacancy.Salary,
                Company = vacancy.Company,
                Requirements = vacancy.Requirements,
                JobInformation = vacancy.JobInformation,
                Email = vacancy.Email,
                CategoryId = vacancy.CategoryId,
                CityId = vacancy.CityId,
                EducationId = vacancy.EducationId,
                EndDate = vacancy.EndDate,
                ExperienceId = vacancy.ExperienceId,
                PhoneNumber = vacancy.PhoneNumber,
                Position = vacancy.Position
            };
            return View(viewModel);

        }

        private VacancyViewModel ViewModel(VacancyModel model)
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
                VacancyModel = model
            };

            return viewmodel;
        }
    }
}
