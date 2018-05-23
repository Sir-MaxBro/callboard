using Callboard.App.Business.Repositories;
using Callboard.App.General.Helpers;
using Callboard.App.General.Loggers;
using Callboard.App.Web.Models;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class AdController : Controller
    {
        private IAdRepository _repository;
        private ILoggerWrapper _logger;
        public AdController(IAdRepository repository, ILoggerWrapper logger)
        {
            Checker.CheckForNull(logger);
            Checker.CheckForNull(repository);
            _logger = logger;
            _repository = repository;
        }

        public ActionResult GetAdList()
        {
            AdViewModel model = new AdViewModel
            {
                Ads = _repository.GetAds()
            };
            return View("AdList", model);
        }

        public ActionResult GetAdsByCategoryId(int categoryId)
        {
            Checker.CheckId(categoryId, $"CategoryId in GetAdsByCategoryId method is not valid.");
            AdViewModel model = new AdViewModel
            {
                Ads = _repository.GetAdsByCategoryId(categoryId)
            };
            return View("AdList", model);
        }
    }
}