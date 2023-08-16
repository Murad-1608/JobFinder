using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService= contactService;
        }

        #region Index
        public IActionResult Index()
        {
            List<Contact> contacts = _contactService.GetAll();
            return View(contacts);
        }
        #endregion

        #region Detail
        public IActionResult Detail(int id)
        {
            Contact contact = _contactService.GetById(id);
            if (contact == null) return BadRequest();

            return View(contact);
        }
        #endregion
    }
}
