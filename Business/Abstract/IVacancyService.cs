using Entity.Concrete;

namespace Business.Abstract
{
    public interface IVacancyService
    {
        List<Vacancy> GetWithCity();
    }
}
