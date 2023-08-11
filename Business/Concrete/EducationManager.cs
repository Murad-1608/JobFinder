using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
	public class EducationManager : IEducationService
	{
		private readonly IEducationDal _educationDal;
        public EducationManager(IEducationDal educationDal)
        {
			_educationDal = educationDal;
        }
		public void Add(Education education) => _educationDal.Add(education);
		

		public void Delete(int id)
		{
			Education education = _educationDal.Get(x => x.Id == id);
			_educationDal.Delete(education);
		}

		public List<Education> GetAll() => _educationDal.GetAll();


		public Education GetById(int id) => _educationDal.Get(x => x.Id == id);


		public void Update(Education education) => _educationDal.Update(education);
		
	}
}
