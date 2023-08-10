
using Entity.Concrete;

namespace Business.Abstract
{
	public interface IBlogService
	{
		List<Blog> GetAll();
		Blog GetById(int id);
		void Add(Blog blog);
		void Update(Blog blog);
		void Delete(int id);
	}
}
