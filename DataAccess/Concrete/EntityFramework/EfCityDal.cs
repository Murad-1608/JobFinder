using Core.DataAccess.EntityFramework;
using Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCityDal : EfRepositoryBase<City, AppDbContext>
    {
    }
}
