using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models.ViewModels;

namespace WebUI.ViewComponents
{
    public class Filter : ViewComponent
    {
        private readonly ICategoryService categoryService;
        private readonly ICityService cityService;
        public Filter(ICategoryService categoryService, ICityService cityService)
        {
            this.categoryService = categoryService;
            this.cityService = cityService;
        }

        public IViewComponentResult Invoke()
        {
            FilterViewModel viewModel = new FilterViewModel();

            viewModel.Cateories = categoryService.GetAll();
            viewModel.Cities = cityService.GetAll();

            return View(viewModel);
        }
    }
}
