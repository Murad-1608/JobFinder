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

        public void Add(City city)
        {
            cityDal.Add(city);
        }

        public void Delete(int id)
        {
            var city = cityDal.Get(x => x.Id == id);

            cityDal.Delete(city);
        }

        public List<City> GetAll() => cityDal.GetAll();
    }
}
