using Callboard.App.Business.Services;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Loggers.Main;
using Callboard.App.Web.Models;
using System;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class CommercialController : Controller
    {
        private IChecker _checker;
        private ILoggerWrapper _logger;
        private ICommercialService _commercialProvider;
        public CommercialController(ILoggerWrapper logger, ICommercialService commercialProvider, IChecker checker)
        {
            if (checker == null)
            {
                throw new NullReferenceException(nameof(checker));
            }
            _checker = checker;
            _checker.CheckForNull(logger);
            _checker.CheckForNull(commercialProvider);
            _logger = logger;
            _commercialProvider = commercialProvider;
        }

        public PartialViewResult GetCommercial()
        {
            var model = new CommercialViewModel
            {
                Commercials = _commercialProvider.GetCommercials()
            };
            return PartialView("CommercialPartial", model);
        }
    }
}