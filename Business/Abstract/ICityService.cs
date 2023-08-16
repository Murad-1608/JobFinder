using Entity.Concrete;

namespace Business.Abstract
{
    public interface ICityService
    {
        List<City> GetAll();
        void Add(City city);
        void Delete(int id);
    }
}
