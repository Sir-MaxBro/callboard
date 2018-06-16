using Callboard.App.Business.Services;
using Callboard.App.General.Entities;
using Callboard.App.General.Entities.Data;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Loggers.Main;
using Callboard.App.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class SearchController : Controller
    {
        private IAdService _adProvider;
        private IChecker _checker;
        private ILoggerWrapper _logger;
        public SearchController(IAdService adProvider, ILoggerWrapper logger, IChecker checker)
        {
            if (checker == null)
            {
                throw new NullReferenceException(nameof(checker));
            }
            _checker = checker;
            _checker.CheckForNull(logger);
            _checker.CheckForNull(adProvider);
            _logger = logger;
            _adProvider = adProvider;
        }

        public ActionResult SearchAdsByName(string name)
        {
            IReadOnlyCollection<Ad> ads = null;

            if (string.IsNullOrEmpty(name))
            {
                ads = _adProvider.GetAds();
            }
            else
            {
                ads = _adProvider.SearchByName(name);
            }

            SearchViewModel model = new SearchViewModel
            {
                Ads = ads,
                SearchConfiguration = new SearchConfiguration()
            };

            return View("Search", model);
        }

        public ActionResult Search()
        {
            var model = new SearchViewModel
            {
                Ads = _adProvider.GetAds(),
                SearchConfiguration = new SearchConfiguration()
            };

            return View(model);
        }

        public ActionResult SearchAds(string searchConfigurationData)
        {
            IReadOnlyCollection<Ad> ads = null;
            searchConfigurationData = searchConfigurationData ?? string.Empty;
            var searchConfiguration = JsonConvert.DeserializeObject<SearchConfiguration>(searchConfigurationData);

            if (searchConfiguration == null)
            {
                ads = _adProvider.GetAds();
            }
            else
            {
                ads = _adProvider.Search(searchConfiguration);
            }

            return PartialView("Partial\\AdContainer", ads);
        }
    }
}