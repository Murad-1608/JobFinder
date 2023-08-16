using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.Admin.Models
{
    public class CategoryModel
    {
        [Required(ErrorMessage = "Kateqoriyanı qeyd edin")]
        public string Name { get; set; }
    }
}
