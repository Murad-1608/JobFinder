using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
	public class EducationModel
	{
		[Required(ErrorMessage ="Bu xana boş keçilə bilməz")]
		public string Education { get; set; }
	}
}
