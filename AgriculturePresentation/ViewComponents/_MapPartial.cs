using Microsoft.AspNetCore.Mvc;
using Agriculture.BusinessLayer.Abstract;
using Agriculture.DataAccessLayer.Concrete;

namespace Agriculture.Presentation.ViewComponents
{
    public class _MapPartial : ViewComponent
    {
        private readonly IAddressService _addressService;

        public _MapPartial(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public IViewComponentResult Invoke()
        {
            AgricultureContext context = new AgricultureContext();
            var value = context.Addresses.Select(x => x.MapInfo).FirstOrDefault();
            ViewBag.v = value;
            return View();
        }
    }
}
