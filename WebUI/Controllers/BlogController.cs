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
		public IActionResult Index()
		{
			List<Blog> blogs = _blogService.GetAll();
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
