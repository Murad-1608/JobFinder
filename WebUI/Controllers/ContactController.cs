using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebUI.Constants;
using WebUI.Models;

namespace WebUI.Controllers
{
	public class ContactController : Controller
	{
		private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService=contactService;
        }

		#region Index
		public IActionResult Index()
		{
			Header.Name = "Əlaqə";
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Index(ContactModel model)
		{
			if (ModelState.IsValid)
			{
				Contact contact = new Contact
				{
					Address = model.FullName,
					Email = model.Email,
					Subject = model.Subject,
					Message = model.Message,
					CreateDate = model.CreateDate
				};
				_contactService.Add(contact);
				return RedirectToAction("Index");
			}
			return View();
		}
		#endregion
	}
}
