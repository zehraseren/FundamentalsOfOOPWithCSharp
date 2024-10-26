using EntityLayer.Concrete;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;

namespace DemoProduct.Controllers
{
    public class JobController : Controller
    {
        JobManager _jobManager = new JobManager(new EfJobDal());

        public IActionResult Index()
        {
            var values = _jobManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddJob()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddJob(Job job)
        {
            ModelState.Clear();
            JobValidator validationRules = new JobValidator();
            ValidationResult results = validationRules.Validate(job);
            if (results.IsValid)
            {
                _jobManager.TInsert(job);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteJob(int id)
        {
            var value = _jobManager.TGetById(id);
            _jobManager.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateJob(int id)
        {
            var value = _jobManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateJob(Job job)
        {
            _jobManager.TUpdate(job);
            return RedirectToAction("Index");
        }
    }
}
