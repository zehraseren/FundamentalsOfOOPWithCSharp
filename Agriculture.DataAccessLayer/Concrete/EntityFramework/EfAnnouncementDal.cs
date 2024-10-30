using Agriculture.EntityLayer.Concrete;
using Agriculture.DataAccessLayer.Abstract;
using Agriculture.DataAccessLayer.Concrete.Repository;

namespace Agriculture.DataAccessLayer.Concrete.EntityFramework
{
    public class EfAnnouncementDal : GenericRepository<Announcement>, IAnnouncementDal
    {
        public void AnnouncementStatusToFalse(int id)
        {
            using var context = new AgricultureContext();
            Announcement c = context.Announcements.Find(id);
            c.Status = false;
            context.SaveChanges();
        }

        public void AnnouncementStatusToTrue(int id)
        {
            using var context = new AgricultureContext();
            Announcement c = context.Announcements.Find(id);
            c.Status = true;
            context.SaveChanges();
        }
    }
}
