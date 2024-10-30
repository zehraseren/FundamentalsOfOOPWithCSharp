using Agriculture.EntityLayer.Concrete;

namespace Agriculture.BusinessLayer.Abstract
{
    public interface IAnnouncementService : IGenericService<Announcement>
    {
        void AnnouncementStatusToTrue(int id);
        void AnnouncementStatusToFalse(int id);
    }
}
