using Callboard.App.General.Loggers;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class CommercialController : Controller
    {
        private ILoggerWrapper _logger;
        public CommercialController(ILoggerWrapper logger)
        {
            _logger = logger;
        }

        public PartialViewResult GetCommercial()
        {
            return PartialView("CommercialPartial", null);
        }
    }
}