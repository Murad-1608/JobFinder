using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        public List<Category> GetAll() => categoryDal.GetAll();
    }
}
