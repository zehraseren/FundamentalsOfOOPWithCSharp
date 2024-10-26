using EntityLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfCustomerDal : GenericRepository<Customer>, ICustomerDal
    {
        // Sadece Customer entity'sine ait metotlar buraya tanımlanır.
        public List<Customer> GetCustomerListWithJob()
        {
            using (var context = new Context())
            {
                return context.Customers.Include(x => x.Job).ToList();
            }
        }
    }
}
