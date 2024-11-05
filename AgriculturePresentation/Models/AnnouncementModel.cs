namespace Agriculture.Presentation.Models
{
    public class AnnouncementModel
    {
        public int AnnouncementId { get; set; }
        public string AnnouncementName { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
