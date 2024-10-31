using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Agriculture.EntityLayer.Concrete;
using Agriculture.BusinessLayer.Abstract;
using Agriculture.BusinessLayer.ValidationRules;

namespace Agriculture.Presentation.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public IActionResult Index()
        {
            var values = _addressService.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult UpdateAddress(int id)
        {
            var value = _addressService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateAddress(Address address)
        {
            AddressValidator validationRules = new AddressValidator();
            ValidationResult result = validationRules.Validate(address);
            if (result.IsValid)
            {
                _addressService.Update(address);
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