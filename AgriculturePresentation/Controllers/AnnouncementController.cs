using Microsoft.AspNetCore.Mvc;
using Agriculture.EntityLayer.Concrete;
using Agriculture.BusinessLayer.Abstract;

namespace Agriculture.Presentation.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IActionResult Index()
        {
            var value = _announcementService.GetList();
            return View(value);
        }

        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View(new Announcement());
        }

        [HttpPost]
        public IActionResult AddAnnouncement(Announcement announcement)
        {
            announcement.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            announcement.Status = false;
            _announcementService.Insert(announcement);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAnnouncement(int id)
        {
            var value = _announcementService.GetById(id);
            _announcementService.Delete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {
            var value = _announcementService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateAnnouncement(Announcement announcement)
        {
            _announcementService.Update(announcement);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeToStatusTrue(int id)
        {
            _announcementService.AnnouncementStatusToTrue(id);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeToStatusFalse(int id)
        {
            _announcementService.AnnouncementStatusToFalse(id);
            return RedirectToAction("Index");
        }
    }
}
