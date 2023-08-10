using Core.DataAccess.EntityFramework;
using Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfRepositoryBase<Category, AppDbContext>
    {
    }
}
