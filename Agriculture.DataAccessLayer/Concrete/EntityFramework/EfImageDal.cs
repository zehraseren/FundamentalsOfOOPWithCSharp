using Agriculture.EntityLayer.Concrete;
using Agriculture.DataAccessLayer.Abstract;
using Agriculture.DataAccessLayer.Concrete.Repository;

namespace Agriculture.DataAccessLayer.Concrete.EntityFramework
{
    internal class EfImageDal : GenericRepository<Image>, IImageDal
    {
    }
}
