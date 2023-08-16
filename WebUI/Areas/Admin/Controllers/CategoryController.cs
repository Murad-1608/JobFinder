using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.Models;
using X.PagedList;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = categoryService.GetAll().ToPagedList(1, 10);
            return View(categories);
        }

        public IActionResult Delete(int id)
        {
            categoryService.Delete(id);

            return RedirectPermanent("/admin/category/index");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                Category category = new()
                {
                    Name = model.Name
                };
                categoryService.Add(category);

                return RedirectPermanent("/admin/category/index");

            }
            return View(model);

        }
    }
}
