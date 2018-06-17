using Callboard.App.Business.Services;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Loggers.Main;
using Callboard.App.General.ResultExtensions;
using Callboard.App.Web.Attributes;
using Callboard.App.Web.Models;
using System;
using System.Collections.Generic;
using System.Net;
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
            IReadOnlyCollection<Ad> ads = new List<Ad>();
            var adsResult = _adProvider.GetAds();
            if (adsResult.IsSuccess())
            {
                ads = adsResult.GetSuccessResult();
            }

            AdListViewModel model = new AdListViewModel
            {
                Ads = ads
            };

            return View("AdList", model);
        }

        public ActionResult GetAdsByCategoryId(int categoryId)
        {
            IReadOnlyCollection<Ad> ads = new List<Ad>();
            var adsResult = _adProvider.GetAdsByCategoryId(categoryId);
            if (adsResult.IsSuccess())
            {
                ads = adsResult.GetSuccessResult();
            }

            AdListViewModel model = new AdListViewModel
            {
                Ads = ads
            };

            return View("AdList", model);
        }

        [User]
        public PartialViewResult GetAdsForUser(int userId)
        {
            IReadOnlyCollection<Ad> ads = new List<Ad>();
            var adsResult = _adProvider.GetAdsForUser(userId);
            if (adsResult.IsSuccess())
            {
                ads = adsResult.GetSuccessResult();
            }

            return PartialView("Partial\\AdContainer", ads);
        }

        [User]
        public ActionResult DeleteAd(int adId, string returnUrl)
        {
            var adsResult = _adProvider.Delete(adId);
            if (adsResult.IsNone())
            {
                return RedirectToAction("GetAdList", "Ad");
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}