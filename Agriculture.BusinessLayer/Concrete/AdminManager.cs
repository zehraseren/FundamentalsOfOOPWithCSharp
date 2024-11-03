using Agriculture.EntityLayer.Concrete;
using Agriculture.BusinessLayer.Abstract;
using Agriculture.DataAccessLayer.Abstract;

namespace Agriculture.BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void Delete(Admin t)
        {
            _adminDal.Delete(t);
        }

        public Admin GetById(int id)
        {
            return _adminDal.GetById(id);
        }

        public List<Admin> GetList()
        {
            return _adminDal.GetList();
        }

        public void Insert(Admin t)
        {
            _adminDal.Insert(t);
        }

        public void Update(Admin t)
        {
            _adminDal.Update(t);
        }
    }
}
