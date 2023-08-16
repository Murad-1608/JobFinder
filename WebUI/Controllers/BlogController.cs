using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
	public class BlogController : Controller
	{
		private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
			_blogService = blogService;
        }

		#region Index
		public IActionResult Index(string search,int page=1)
		{
			Constants.Header.Name = "Bloqlar";

            List<Blog> blogs = new List<Blog>();

			if (!string.IsNullOrEmpty(search))
			{
				var blg = from x in _blogService.GetAll() select x;
				blogs = _blogService.GetAll().Where(x => x.Title.Contains(search)).ToList();
				return View(blogs);
			}

            decimal take = 3;
			ViewBag.PageCount = Math.Ceiling((decimal)(_blogService.GetAll().Count() / take));
			ViewBag.CurrentPage = page;

			blogs =_blogService.GetAll().OrderByDescending(x => x.Id).Skip((page - 1)*(int)take).Take((int)take).ToList();
			return View(blogs);
		}
		#endregion

		#region GetById
		public IActionResult Detail(int id)
		{
			Blog blog = _blogService.GetById(id);
			return View(blog);
		}
		#endregion
	}
}
