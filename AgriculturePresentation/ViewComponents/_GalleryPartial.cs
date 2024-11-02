using Microsoft.AspNetCore.Mvc;
using Agriculture.BusinessLayer.Abstract;

namespace Agriculture.Presentation.ViewComponents
{
    public class _GalleryPartial : ViewComponent
    {
        private readonly IImageService _imageService;

        public _GalleryPartial(IImageService imageService)
        {
            _imageService = imageService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _imageService.GetList();
            return View(values);
        }
    }
}
