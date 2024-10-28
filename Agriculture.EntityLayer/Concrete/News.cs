namespace Agriculture.EntityLayer.Concrete
{
    public class News
    {
        public int NewsId { get; set; }
        public string NewsName { get; set; }
        public string NewsDescription { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
