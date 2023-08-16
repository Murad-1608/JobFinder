using Business.Abstract;
using Business.Helper;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class BlogController : Controller
	{
		private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService=blogService;
        }

		#region Index
		public IActionResult Index(int page = 1)
		{
			List<Blog> blogs = new List<Blog>();

			decimal take = 10;
			ViewBag.PageCount = Math.Ceiling((decimal)(_blogService.GetAll().Count() / take));
			ViewBag.CurrentPage = page;

			blogs = _blogService.GetAll().OrderByDescending(x => x.Id).Skip((page - 1) * (int)take).Take((int)take).ToList();
			return View(blogs);
		}
		#endregion

		#region Create
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Create(BlogModel model)
		{
			if (ModelState.IsValid)
			{
				bool isExist = _blogService.GetAll().Any(x => x.Title == model.Title);
				if (isExist)
				{
					ModelState.AddModelError("Title", "Bu adda blog hal-hazırda mövcuddur");
					return View();
				}
				SystemIOOperations.AddPhoto(model.Photo, "Template/Job/img/blog");
                Blog blog = new Blog
				{
					Title = model.Title,
					Description = model.Description,
					CreateDate = model.Created,
					Image = model.Image
				};

				_blogService.Add(blog);
				return RedirectToAction("Index");
			}
			return View();
		}
		#endregion

		#region Detail
		public IActionResult Detail(int id)
		{
			Blog blog = _blogService.GetById(id);
			if (blog == null)
				return BadRequest();

			return View(blog);
		}
		#endregion
	}
}
