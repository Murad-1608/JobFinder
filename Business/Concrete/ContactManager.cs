using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
	public class ContactManager : IContactService
	{
		private readonly IContactDal _contactDal;
        public ContactManager(IContactDal contactDal)
        {
            _contactDal= contactDal;
        }

        public void Add(Contact contact) => _contactDal.Add(contact);
		

		public void Delete(int id)
		{
			Contact contact = _contactDal.Get(x=>x.Id== id);
			_contactDal.Delete(contact);
		}

		public List<Contact> GetAll() => _contactDal.GetAll();


		public Contact GetById(int id) => _contactDal.Get(x => x.Id == id);
		
	}
}
