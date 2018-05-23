using Callboard.App.Business.Repositories;
using Callboard.App.General.Helpers;
using Callboard.App.Web.Models;
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

        [HttpPost]
        public PartialViewResult GetImagesByAdId(int adId)
        {
            Checker.CheckId(adId, $"AdId in GetImagesByAdId method is not valid.");
            var model = new ImageViewModel
            {
                Images = _repository.GetImagesByAdId(adId)
            };
            return PartialView("ImagesSlider", model);
        }
    }
}