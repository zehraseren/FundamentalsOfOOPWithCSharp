using Microsoft.AspNetCore.Mvc;
using Agriculture.DataAccessLayer.Concrete;

namespace Agriculture.Presentation.ViewComponents
{
    public class _DashboardOverViewPartial : ViewComponent
    {
        AgricultureContext context = new AgricultureContext();

        public IViewComponentResult Invoke()
        {
            DateTime dt = DateTime.Now;
            ViewBag.teamCount = context.Teams.Count();
            ViewBag.serviceCount = context.Services.Count();
            ViewBag.messageCount = context.Contacts.Count();
            ViewBag.currentMonthCount = context.Contacts.Where(x => x.Date.Month == dt.Month).Count();

            ViewBag.announcementTrue = context.Announcements.Where(x => x.Status == true).Count();
            ViewBag.announcementFalse = context.Announcements.Where(x => x.Status == false).Count();

            ViewBag.engineerCount = context.Teams.Where(x => x.PersonTitle == "Ziraat Mühendisi").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.manufacturerCount = context.Teams.Where(x => x.PersonTitle == "Süt Ürünleri Üreticisi").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.managerCount = context.Teams.Where(x => x.PersonTitle == "Satış Müdürü").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.directorCount = context.Teams.Where(x => x.PersonTitle == "Saha Direktörü").Select(y => y.PersonName).FirstOrDefault();
            return View();
        }
    }
}
