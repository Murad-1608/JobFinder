

using Entity.Concrete;

namespace Business.Abstract
{
	public interface IContactService
	{
		List<Contact> GetAll();
		Contact GetById(int id);
		void Add(Contact contact);
		void Delete(int id);
	}
}
