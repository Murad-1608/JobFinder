using Core.DataAccess.EntityFramework;
using Core.Entity.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfVacancyDal : EfRepositoryBase<Vacancy, AppDbContext>, IVacancyDal
    {
        public List<Vacancy> GetWithCity(Expression<Func<Vacancy, bool>> filter = null)
        {
            using (var context = new AppDbContext())
            {
                return filter == null ? context.Vacancies.Where(x => x.IsActive == true).Include(x => x.City).ToList() :
                                        context.Vacancies.Where(filter).Where(x => x.IsActive == true).Include(x => x.City).ToList();


            }
        }

        public List<Vacancy> GetWithCityAndEducationAndCategoryAndExperience(Expression<Func<Vacancy, bool>> filter = null)
        {
            using (var context = new AppDbContext())
            {
                return filter == null ? context.Vacancies.Where(x => x.IsActive == true).
                    Include(x => x.City).
                    Include(x => x.Category).
                    Include(x => x.Experience).
                    Include(x => x.Education).ToList() :
                                        context.Vacancies.Where(filter).Where(x => x.IsActive == true).
                                        Include(x => x.City).
                                        Include(x => x.City).
                                        Include(x => x.Category).Include(x => x.Experience).
                                        Include(x => x.Education).ToList();


            }
        }
    }
}
