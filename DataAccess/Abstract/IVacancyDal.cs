using Core.DataAccess;
using Core.Entity.Abstract;
using Entity.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IVacancyDal : IRepositoryBase<Vacancy>
    {
        List<Vacancy> GetWithCity(Expression<Func<Vacancy, bool>> filter = null);
        List<Vacancy> GetWithCityAndEducationAndCategoryAndExperience(Expression<Func<Vacancy, bool>> filter = null);
    }
}
