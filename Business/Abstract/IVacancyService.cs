using Entity.Concrete;

namespace Business.Abstract
{
    public interface IVacancyService
    {
        List<Vacancy> GetWithCityIsActive();
        List<Vacancy> GetWithCityIsFalse();
        List<Vacancy> Filter(int cityId, int categoryId, int educationId, int experienceId, string search);
        Vacancy Details(int id);
        void Add(Vacancy vacancy);
        void Update(Vacancy vacancy);
        void Delete(Vacancy vacancy);
        Vacancy GetById(int id);
    }
}
