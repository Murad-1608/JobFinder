using Entity.Concrete;

namespace Business.Abstract
{
    public interface IVacancyService
    {
        List<Vacancy> GetWithCity();
        List<Vacancy> Filter(int cityId, int categoryId, int educationId, int experienceId, string search);
        Vacancy Details(int id);
        void Add(Vacancy vacancy);
    }
}
