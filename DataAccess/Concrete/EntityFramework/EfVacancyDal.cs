using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfVacancyDal : EfRepositoryBase<Vacancy, AppDbContext>, IVacancyDal
    {
        public List<Vacancy> GetWithCity()
        {
            using (var context = new AppDbContext())
            {
                return context.Vacancies.Where(x => x.IsActive == true).Include(x => x.City).ToList();
            }
        }
    }
}
