using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Areas.Admin.Models.ViewModels
{
    public class VacancyViewModel
    {
        public VacancyModel VacancyModel { get; set; }
        public List<SelectListItem>? Cities { get; set; }
        public List<SelectListItem>? Categories { get; set; }
        public List<SelectListItem>? Educations { get; set; }
        public List<SelectListItem>? Experiences { get; set; }
    }
}
