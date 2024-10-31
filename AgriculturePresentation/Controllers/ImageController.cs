using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Agriculture.EntityLayer.Concrete;
using Agriculture.BusinessLayer.Abstract;
using Agriculture.BusinessLayer.ValidationRules;

namespace Agriculture.Presentation.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            var values = _imageService.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddImage(Image image)
        {
            ModelState.Clear();
            ImageValidator validationRules = new ImageValidator();
            ValidationResult result = validationRules.Validate(image);
            if (result.IsValid)
            {
                _imageService.Insert(image);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,
                       item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult DeleteImage(int id)
        {
            var value = _imageService.GetById(id);
            _imageService.Delete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateImage(int id)
        {
            var value = _imageService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateImage(Image image)
        {
            ImageValidator validationRules = new ImageValidator();
            ValidationResult result = validationRules.Validate(image);
            if (result.IsValid)
            {
                _imageService.Update(image);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,
                       item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
