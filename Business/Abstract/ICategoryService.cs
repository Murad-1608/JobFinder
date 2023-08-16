using Entity.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        void Delete(int id);
        void Add(Category category);
    }
}
