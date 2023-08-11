using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
	public class BlogManager : IBlogService
	{
		private readonly IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public void Add(Blog blog) => _blogDal.Add(blog);
		

		public void Delete(int id)
		{
			Blog blog = _blogDal.Get(x => x.Id == id);
			_blogDal.Delete(blog);
		}

		public List<Blog> GetAll() => _blogDal.GetAll();


		public Blog GetById(int id) => _blogDal.Get(x => x.Id == id);


		public void Update(Blog blog) => _blogDal.Update(blog);
		
	}
}
