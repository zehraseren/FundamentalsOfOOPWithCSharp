using Agriculture.EntityLayer.Concrete;
using Agriculture.DataAccessLayer.Abstract;
using Agriculture.DataAccessLayer.Concrete.Repository;

namespace Agriculture.DataAccessLayer.Concrete.EntityFramework
{
    public class EfTeamDal : GenericRepository<Team>, ITeamDal
    {
    }
}
