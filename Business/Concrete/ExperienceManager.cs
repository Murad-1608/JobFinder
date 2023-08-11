using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System.Linq.Expressions;

namespace Business.Concrete
{
	public class ExperienceManager : IExperienceService
	{
		private readonly IExperienceDal _experienceDal;
        public ExperienceManager(IExperienceDal experienceDal)
        {
			_experienceDal = experienceDal;
        }

		public void Add(Experience experience) => _experienceDal.Add(experience);
		

		public void Delete(int id)
		{
			Experience experience = _experienceDal.Get(x => x.Id == id);
			_experienceDal.Delete(experience);
		}

		public List<Experience> GetAll() => _experienceDal.GetAll();


		public Experience GetById(int id) => _experienceDal.Get(x => x.Id == id);


		public void Update(Experience experience) => _experienceDal.Update(experience);
		
	}
}
