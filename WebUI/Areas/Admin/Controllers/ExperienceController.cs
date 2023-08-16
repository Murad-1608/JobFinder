using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExperienceController : Controller
    {
        private readonly IExperienceService _experienceService;
        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        #region Index
        public IActionResult Index()
        {
            List<Experience> experiences = _experienceService.GetAll();
            return View(experiences);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(ExperienceModel model)
        {
            if (ModelState.IsValid)
            {
                Experience experience = new Experience
                {
                    Name = model.Name
                };
                _experienceService.Add(experience);
                return RedirectToAction("Index");
            }
            return View();
        }
        #endregion

        #region Update
        public IActionResult Update(int id)
        {
            Experience dbexperience = _experienceService.GetById(id);
            if (dbexperience == null)
                return BadRequest();

            return View(dbexperience);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(int id,ExperienceModel model)
        {
            Experience dbexperience = _experienceService.GetById(id);
            if (dbexperience == null)
                return BadRequest();

            if (ModelState.IsValid)
            {
                dbexperience.Name = model.Name;
                Experience experience = new Experience
                {
                    Name = model.Name
                };
                _experienceService.Update(experience);
                return RedirectToAction("Index");
            }
            return View();
        }
        #endregion
    }
}
