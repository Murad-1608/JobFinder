using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents
{
    public class Filter : ViewComponent
    {
        private readonly ICategoryService categoryService;
        public Filter(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            
            return View();
        }
    }
}
