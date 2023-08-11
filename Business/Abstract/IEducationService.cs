using Entity.Concrete;

namespace Business.Abstract
{
	public interface IEducationService
	{
		List<Education> GetAll();
		Education GetById(int id);
		void Add(Education education);
		void Update(Education education);
		void Delete(int id);
	}
}
