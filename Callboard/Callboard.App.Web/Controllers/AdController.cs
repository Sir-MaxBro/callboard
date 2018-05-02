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

        // GET: Home
        public ActionResult Index()
        {
            AdViewModel model = new AdViewModel
            {
                Ads = _repository.Items.ToList()
            };
            return View(model);
        }

        public ActionResult GetCategoryAds(int categoryID)
        {
            AdViewModel model = new AdViewModel
            {
                Ads = _repository.GetCategoryAds(categoryID).ToList()
            };

            _logger.InfoFormat($"Get elements by categoryID: { categoryID }", null);

            return View("Index", model);
        }

        public ActionResult GetAd(int adID, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            var model = _repository.GetAd(adID);

            _logger.InfoFormat($"Get ad by adID: { adID }", null);

            return View("AdInformation", model);
        }
    }
}