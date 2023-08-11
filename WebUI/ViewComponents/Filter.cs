using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models.ViewModels;

namespace WebUI.ViewComponents
{
    public class Filter : ViewComponent
    {
        private readonly ICategoryService categoryService;
        private readonly ICityService cityService;
        private readonly IEducationService educationService;
        private readonly IExperienceService experienceService;
        public Filter(ICategoryService categoryService, ICityService cityService, IEducationService educationService, IExperienceService experienceService)
        {
            this.categoryService = categoryService;
            this.cityService = cityService;
            this.educationService = educationService;
            this.experienceService = experienceService;
        }

        public IViewComponentResult Invoke()
        {
            FilterViewModel viewModel = new FilterViewModel();

            viewModel.Categories = categoryService.GetAll();
            viewModel.Educations = educationService.GetAll();
            viewModel.Experiences = experienceService.GetAll();
            viewModel.Cities = cityService.GetAll();

            return View(viewModel);
        }
    }
}
