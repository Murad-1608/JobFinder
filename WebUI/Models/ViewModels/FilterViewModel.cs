using Entity.Concrete;

namespace WebUI.Models.ViewModels
{
    public class FilterViewModel
    {
        public List<City> Cities { get; set; }
        public List<Category> Categories { get; set; }
        public List<Education> Educations { get; set; }
        public List<Experience> Experiences { get; set; }
    }
}
