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

        public void Add(Vacancy vacancy)
        {
            vacancyDal.Add(vacancy);
        }

        public void Delete(Vacancy vacancy)
        {
            vacancyDal.Delete(vacancy);
        }

        public Vacancy Details(int id)
        {
            return vacancyDal.GetWithCityAndEducationAndCategoryAndExperience(x => x.Id == id).Last();
        }

        public List<Vacancy> Filter(int cityId, int categoryId, int educationId, int experienceId, string search)
        {
            var vacancies = vacancyDal.GetWithCity(x => (x.CategoryId == categoryId ||
                                                   x.CityId == cityId ||
                                                   x.EducationId == educationId ||
                                                   x.ExperienceId == experienceId ||
                                                   x.Position.Contains(search) ||
                                                   x.JobInformation.Contains(search) ||
                                                   x.Requirements.Contains(search)));

            return vacancies;
        }

        public Vacancy GetById(int id)
        {
            return vacancyDal.Get(x => x.Id == id);
        }

        public List<Vacancy> GetWithCityIsActive() => vacancyDal.GetWithCity(x => x.IsActive == true);
        public List<Vacancy> GetWithCityIsFalse() => vacancyDal.GetWithCity(x => x.IsActive == false);

        public void Update(Vacancy vacancy)
        {
            vacancyDal.Update(vacancy);
        }
    }
}
