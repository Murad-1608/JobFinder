using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class CityManager : ICityService
    {
        private readonly ICityDal cityDal;
        public CityManager(ICityDal cityDal)
        {
            this.cityDal = cityDal;
        }

        public List<City> GetAll() => cityDal.GetAll();
    }
}
