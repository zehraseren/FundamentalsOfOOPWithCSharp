namespace Agriculture.EntityLayer.Concrete
{
    public class Announcement
    {
        public int AnnouncementId { get; set; }
        public string AnnouncementName { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
