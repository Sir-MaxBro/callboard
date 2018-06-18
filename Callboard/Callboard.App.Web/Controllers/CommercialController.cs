using Callboard.App.Business.Services;
using Callboard.App.General.Entities.Commercial;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Loggers.Main;
using Callboard.App.General.ResultExtensions;
using Callboard.App.Web.Models;
using System;
using System.Collections.Generic;
using System.Net;
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

        public ActionResult GetCommercial()
        {
            IReadOnlyCollection<Commercial> commercials = new List<Commercial>();

            var commercialResult = _commercialProvider.GetCommercials();
            if (commercialResult.IsSuccess())
            {
                commercials = commercialResult.GetSuccessResult();
            }

            var model = new CommercialViewModel { Commercials = commercials };
            return PartialView("CommercialPartial", model);
        }
    }
}