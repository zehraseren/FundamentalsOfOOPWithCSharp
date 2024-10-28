using Agriculture.EntityLayer.Concrete;
using Agriculture.BusinessLayer.Abstract;
using Agriculture.DataAccessLayer.Abstract;

namespace Agriculture.BusinessLayer.Concrete
{
    public class TeamManager : ITeamService
    {
        private readonly ITeamDal _teamDal;

        public TeamManager(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }

        public void Delete(Team t)
        {
            _teamDal.Delete(t);
        }

        public Team GetById(int id)
        {
            return _teamDal.GetById(id);
        }

        public List<Team> GetList()
        {
            return _teamDal.GetList();
        }

        public void Insert(Team t)
        {
            _teamDal.Insert(t);
        }

        public void Update(Team t)
        {
            _teamDal.Update(t);
        }
    }
}
