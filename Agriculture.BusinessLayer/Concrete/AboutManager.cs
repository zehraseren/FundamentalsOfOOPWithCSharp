using Agriculture.EntityLayer.Concrete;
using Agriculture.BusinessLayer.Abstract;
using Agriculture.DataAccessLayer.Abstract;

namespace Agriculture.BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Delete(About t)
        {
            throw new NotImplementedException();
        }

        public About GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<About> GetList()
        {
            return _aboutDal.GetList();
        }

        public void Insert(About t)
        {
            throw new NotImplementedException();
        }

        public void Update(About t)
        {
            throw new NotImplementedException();
        }
    }
}
