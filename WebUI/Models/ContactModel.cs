using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
	public class ContactModel
	{
		[Required(ErrorMessage ="Bu xana boş keçilə bilməz")]
		[EmailAddress(ErrorMessage ="Emailinizi düzgün formada qeyd edin")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Bu xana boş keçilə bilməz")]
		public string FullName { get; set; }
		[Required(ErrorMessage = "Bu xana boş keçilə bilməz")]
		public string Subject { get; set; }
		[Required(ErrorMessage = "Bu xana boş keçilə bilməz")]
		public string Message { get; set; }
		public DateTime CreateDate { get; set; } = DateTime.UtcNow.AddHours(4);
	}
}
