using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI.Models
{
    public class BlogModel
    {
        [Required(ErrorMessage ="Bu xana boş keçilə bilməz")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Bu xana boş keçilə bilməz")]
        public string Description { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow.AddHours(4);
    }
}
