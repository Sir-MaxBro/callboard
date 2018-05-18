using Callboard.App.Business.Abstract;
using Callboard.App.General.Entities;
using Callboard.App.General.Loggers;
using Callboard.App.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class AdController : Controller
    {
        private IAdRepository _repository;
        private ILoggerWrapper _logger;
        public AdController(IAdRepository repository, ILoggerWrapper logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public ActionResult Index()
        {
            AdViewModel model = new AdViewModel
            {
                Ads = _repository.Items
            };
            return View(model);
        }

        public ActionResult GetCategoryAds(int categoryId)
        {
            AdViewModel model = new AdViewModel
            {
                Ads = _repository.GetCategoryAds(categoryId)
            };

            _logger.InfoFormat($"Get elements by categoryID: { categoryId }", null);

            return View("Index", model);
        }

        public ActionResult GetAd(int adId, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            var model = _repository.GetAd(adId);

            _logger.InfoFormat($"Get ad by adID: { adId }", null);

            return View("AdInformation", model);
        }
    }
}