using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.Admin.Models
{
    public class CityModel
    {
        [Required(ErrorMessage = "Şəhər qeyd edin")]
        public string Name { get; set; }
    }
}
