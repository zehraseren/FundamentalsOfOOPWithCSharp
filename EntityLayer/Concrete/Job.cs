namespace EntityLayer.Concrete
{
    public class Job
    {
        public int JobId { get; set; }
        public string JobName { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
