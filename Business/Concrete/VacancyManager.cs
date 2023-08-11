using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class VacancyManager : IVacancyService
    {
        private readonly IVacancyDal vacancyDal;

        public VacancyManager(IVacancyDal vacancyDal)
        {
            this.vacancyDal = vacancyDal;
        }
        public List<Vacancy> GetWithCity() => vacancyDal.GetWithCity();

    }
}
