using Callboard.App.Business.Providers.Main;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Loggers.Main;
using Callboard.App.Web.Models;
using System;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class SearchController : Controller
    {
        private IAdProvider _adProvider;
        private IChecker _checker;
        private ILoggerWrapper _logger;
        public SearchController(IAdProvider adProvider, ILoggerWrapper logger, IChecker checker)
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
            SearchViewModel model = new SearchViewModel
            {
                Ads = _adProvider.SearchByName(name)
            };
            return View("Search", model);
        }
    }
}