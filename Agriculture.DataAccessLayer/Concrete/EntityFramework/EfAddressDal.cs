using Agriculture.EntityLayer.Concrete;
using Agriculture.DataAccessLayer.Concrete.Repository;
using Agriculture.DataAccessLayer.Abstract;

namespace Agriculture.DataAccessLayer.Concrete.EntityFramework
{
    public class EfAddressDal : GenericRepository<Address>, IAddressDal
    {
    }
}
