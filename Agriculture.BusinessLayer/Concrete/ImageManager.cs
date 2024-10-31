using Agriculture.EntityLayer.Concrete;
using Agriculture.BusinessLayer.Abstract;
using Agriculture.DataAccessLayer.Abstract;

namespace Agriculture.BusinessLayer.Concrete
{
    public class ImageManager : IImageService
    {
        private readonly IImageDal _imageDal;

        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public void Delete(Image t)
        {
            _imageDal.Delete(t);
        }

        public Image GetById(int id)
        {
            return _imageDal.GetById(id);
        }

        public List<Image> GetList()
        {
            return _imageDal.GetList();
        }

        public void Insert(Image t)
        {
            _imageDal.Insert(t);
        }

        public void Update(Image t)
        {
            _imageDal.Update(t);
        }
    }
}
