using EntityLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;

namespace DataAccessLayer.EntityFramework
{
    public class EfJobDal : GenericRepository<Job>, IJobDal
    {
        // Sadece Job entity'sine ait metotlar buraya tanımlanır.
    }
}
