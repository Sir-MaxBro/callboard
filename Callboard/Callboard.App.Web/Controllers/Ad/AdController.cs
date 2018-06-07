using Callboard.App.Business.Providers.Main;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Loggers.Main;
using Callboard.App.Web.Models;
using System;
using System.Web.Mvc;
using Callboard.App.Web.Attributes;

namespace Callboard.App.Web.Controllers
{
    public class AdController : Controller
    {
        private IAdProvider _adProvider;
        private ILoggerWrapper _logger;
        private IChecker _checker;
        public AdController(IAdProvider adProvider, ILoggerWrapper logger, IChecker checker)
        {
            if (checker == null)
            {
                throw new NullReferenceException(nameof(checker));
            }
            _checker = checker;
            _checker.CheckForNull(adProvider);
            _checker.CheckForNull(logger);
            _logger = logger;
            _adProvider = adProvider;
        }

        public ActionResult GetAdList()
        {
            AdListViewModel model = new AdListViewModel
            {
                Ads = _adProvider.GetAds()
            };
            return View("AdList", model);
        }

        public ActionResult GetAdsByCategoryId(int categoryId)
        {
            AdListViewModel model = new AdListViewModel
            {
                Ads = _adProvider.GetAdsByCategoryId(categoryId)
            };
            return View("AdList", model);
        }
        
        [User]
        public PartialViewResult GetAdsForUser(int userId)
        {
            var ads = _adProvider.GetAdsForUser(userId);
            return PartialView("Partial\\AdContainer", ads);
        }
    }
}