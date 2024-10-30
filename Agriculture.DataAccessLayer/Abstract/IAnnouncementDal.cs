using Agriculture.EntityLayer.Concrete;

namespace Agriculture.DataAccessLayer.Abstract
{
    public interface IAnnouncementDal : IGenericDal<Announcement>
    {
        void AnnouncementStatusToTrue(int id);
        void AnnouncementStatusToFalse(int id);
    }
}
