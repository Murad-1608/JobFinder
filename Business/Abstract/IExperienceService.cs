using Entity.Concrete;

namespace Business.Abstract
{
	public interface IExperienceService
	{
		List<Experience> GetAll();
		Experience GetById (int id);
		void Add(Experience experience);
		void Update(Experience experience);
		void Delete(int id);
	}
}
