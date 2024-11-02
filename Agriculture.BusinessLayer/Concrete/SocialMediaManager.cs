using Agriculture.EntityLayer.Concrete;
using Agriculture.BusinessLayer.Abstract;
using Agriculture.DataAccessLayer.Abstract;

namespace Agriculture.BusinessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public void Delete(SocialMedia t)
        {
            _socialMediaDal.Delete(t);
        }

        public SocialMedia GetById(int id)
        {
            return _socialMediaDal.GetById(id);
        }

        public List<SocialMedia> GetList()
        {
            return _socialMediaDal.GetList();
        }

        public void Insert(SocialMedia t)
        {
            _socialMediaDal.Insert(t);
        }

        public void Update(SocialMedia t)
        {
            _socialMediaDal.Update(t);
        }
    }
}
