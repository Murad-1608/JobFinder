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
            vacancyViewModel = ViewModel(new AddVacancyModel());

            return View(vacancyViewModel);
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
                    IsActive = true,
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
