using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface ICustomerDal : IGenericDal<Customer>
    {
        List<Customer> GetCustomerListWithJob();
    }
}
