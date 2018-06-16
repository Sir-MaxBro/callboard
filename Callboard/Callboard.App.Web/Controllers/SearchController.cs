using Callboard.App.Business.Services;
using Callboard.App.General.Entities;
using Callboard.App.General.Entities.Data;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Loggers.Main;
using Callboard.App.General.ResultExtensions;
using Callboard.App.General.Results;
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
            IReadOnlyCollection<Ad> ads = new List<Ad>();
            var adsResult = _adProvider.SearchByName(name);
            if (adsResult.IsSuccess())
            {
                var successResult = adsResult.GetSuccessResult();
                ads = successResult.Value;
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
            IReadOnlyCollection<Ad> ads = new List<Ad>();
            var adsResult = _adProvider.GetAds();
            if (adsResult.IsSuccess())
            {
                var successResult = adsResult.GetSuccessResult();
                ads = successResult.Value;
            }

            var model = new SearchViewModel
            {
                Ads = ads,
                SearchConfiguration = new SearchConfiguration()
            };

            return View(model);
        }

        public ActionResult SearchAds(string searchConfigurationData)
        {
            IReadOnlyCollection<Ad> ads = new List<Ad>();
            IResult<IReadOnlyCollection<Ad>> adsResult = null;
            searchConfigurationData = searchConfigurationData ?? string.Empty;
            var searchConfiguration = JsonConvert.DeserializeObject<SearchConfiguration>(searchConfigurationData);

            if (searchConfiguration == null)
            {
                adsResult = _adProvider.GetAds();
            }
            else
            {
                adsResult = _adProvider.Search(searchConfiguration);
            }

            if (adsResult.IsSuccess())
            {
                var successResult = adsResult.GetSuccessResult();
                ads = successResult.Value;
            }

            return PartialView("Partial\\AdContainer", ads);
        }
    }
}