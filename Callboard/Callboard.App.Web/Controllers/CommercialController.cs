using Callboard.App.Business.Repositories;
using Callboard.App.General.Helpers;
using Callboard.App.General.Loggers;
using Callboard.App.Web.Models;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class CommercialController : Controller
    {
        private ILoggerWrapper _logger;
        private ICommercialRepository _repository;
        public CommercialController(ILoggerWrapper logger, ICommercialRepository repository)
        {
            Checker.CheckForNull(logger);
            Checker.CheckForNull(repository);
            _logger = logger;
            _repository = repository;
        }

        public PartialViewResult GetCommercial()
        {
            var model = new CommercialViewModel
            {
                Commercials = _repository.Items
            };
            return PartialView("CommercialPartial", model);
        }
    }
}