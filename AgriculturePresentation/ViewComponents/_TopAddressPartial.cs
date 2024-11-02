using Microsoft.AspNetCore.Mvc;
using Agriculture.BusinessLayer.Abstract;

namespace Agriculture.Presentation.ViewComponents
{
    public class _TopAddressPartial : ViewComponent
    {
        private readonly IAddressService _addressService;

        public _TopAddressPartial(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _addressService.GetList();
            return View(values);
        }
    }
}
