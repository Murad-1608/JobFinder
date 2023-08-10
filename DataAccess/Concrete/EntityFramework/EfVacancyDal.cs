using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfVacancyDal : EfRepositoryBase<Vacancy, AppDbContext>, IVacancyDal
    {       
    }
}
