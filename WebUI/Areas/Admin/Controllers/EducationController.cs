using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class EducationController : Controller
	{
		private readonly IEducationService _educationService;
        public EducationController(IEducationService educationService)
        {
			_educationService = educationService;
        }

		#region Index
		public IActionResult Index()
		{
			List<Education> educations = _educationService.GetAll();
			return View(educations);
		}
		#endregion

		#region Create
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Create(EducationModel model)
		{
			if (ModelState.IsValid)
			{
                bool isExist = _educationService.GetAll().Any(x => x.Name == model.Education);
				if (isExist)
				{
					ModelState.AddModelError("Education", "Bu adda təhsil növü zatən mövcuddur");
					return View();
				}

                Education education = new Education
				{
					Name = model.Education
				};

                _educationService.Add(education);
				return RedirectToAction("Index");
			}
			return View();
		}
		#endregion

		#region Update
		public IActionResult Update(int id)
		{
			Education dbeducation = _educationService.GetById(id);

			if (dbeducation == null)
				return BadRequest();

			EducationModel dbeducationModel = new EducationModel
			{
				Education = dbeducation.Name
			};
			return View(dbeducationModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Update(int id,Education education)
		{
            Education dbeducation = _educationService.GetById(id);
            if (dbeducation == null) { return BadRequest(); }

            if (ModelState.IsValid)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		#endregion

	}
}
