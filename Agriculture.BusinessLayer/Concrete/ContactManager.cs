using Agriculture.EntityLayer.Concrete;
using Agriculture.BusinessLayer.Abstract;
using Agriculture.DataAccessLayer.Abstract;

namespace Agriculture.BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void Delete(Contact t)
        {
            _contactDal.Delete(t);
        }

        public Contact GetById(int id)
        {
            return _contactDal.GetById(id);
        }

        public List<Contact> GetList()
        {
            return _contactDal.GetList();
        }

        public void Insert(Contact t)
        {
            _contactDal.Insert(t);
        }

        public void Update(Contact t)
        {
            throw new NotImplementedException();
        }
    }
}
