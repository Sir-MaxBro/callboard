using Callboard.App.Business.Services;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Loggers.Main;
using Callboard.App.Web.Attributes;
using Callboard.App.Web.Models;
using System;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class AdController : Controller
    {
        private IAdService _adProvider;
        private ILoggerWrapper _logger;
        private IChecker _checker;
        public AdController(IAdService adProvider, ILoggerWrapper logger, IChecker checker)
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

        [User]
        public ActionResult DeleteAd(int adId, string returnUrl)
        {
            _adProvider.Delete(adId);
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return Redirect("GetAdList");
            }
        }
    }
}