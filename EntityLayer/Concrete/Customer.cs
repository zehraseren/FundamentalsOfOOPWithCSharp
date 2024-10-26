namespace EntityLayer.Concrete
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCity { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}
