using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class ExperienceModel
    {
        [Required(ErrorMessage = "Bu xana boş keçilə bilməz")]
        public string Name { get; set; }
    }
}
