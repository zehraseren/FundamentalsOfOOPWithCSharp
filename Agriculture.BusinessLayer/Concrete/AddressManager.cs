using Agriculture.EntityLayer.Concrete;
using Agriculture.BusinessLayer.Abstract;
using Agriculture.DataAccessLayer.Abstract;

namespace Agriculture.BusinessLayer.Concrete
{
    public class AddressManager : IAddressService
    {
        IAddressDal _addressDal;

        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        public void Delete(Address t)
        {
            throw new NotImplementedException();
        }

        public Address GetById(int id)
        {
            return _addressDal.GetById(id);
        }

        public List<Address> GetList()
        {
            return _addressDal.GetList();
        }

        public void Insert(Address t)
        {
            throw new NotImplementedException();
        }

        public void Update(Address t)
        {
            _addressDal.Update(t);
        }
    }
}
