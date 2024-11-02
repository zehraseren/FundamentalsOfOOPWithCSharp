using Microsoft.AspNetCore.Mvc;
using Agriculture.BusinessLayer.Abstract;

namespace Agriculture.Presentation.ViewComponents
{
    public class _TeamPartial : ViewComponent
    {
        private readonly ITeamService _teamService;

        public _TeamPartial(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _teamService.GetList();
            return View(values);
        }
    }
}
