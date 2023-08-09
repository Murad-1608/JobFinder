using Microsoft.AspNetCore.Mvc;
using WebUI.Constants;

namespace WebUI.Controllers
{
    public class VacancyController : Controller
    {
        public IActionResult Index()
        {
            Header.Name = "Elan";
            return View();
        }
    }
}
