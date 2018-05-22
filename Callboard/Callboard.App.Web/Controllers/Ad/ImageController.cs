using Callboard.App.Business.Repositories;
using Callboard.App.General.Helpers;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class ImageController : Controller
    {
        private IImageRepository _repository;
        public ImageController(IImageRepository repository)
        {
            Checker.CheckForNull(repository, $"Cannot find { typeof(IImageRepository) } in App.Web ImageController");
            _repository = repository;
        }

        public PartialViewResult GetImagesByAdId(int adId)
        {
            var model = _repository.GetImagesByAdId(adId);
            return PartialView("ImagesSlider", model);
        }
    }
}