using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Callboard.App.General.Loggers;
using Callboard.App.Web.CommercialService;
using Callboard.App.Web.Models;

namespace Callboard.App.Web.Controllers
{
    public class CommercialController : Controller
    {
        private ILoggerWrapper _logger;
        public CommercialController(ILoggerWrapper logger)
        {
            _logger = logger;
        }

        // GET: Commercial
        public PartialViewResult GetCommercial()
        {
            ICommercialRepository commercialRepository = new CommercialRepositoryClient();
            CommercialViewModel model = null;
            try
            {
                var commercials = commercialRepository.GetCommercials();
                model = new CommercialViewModel
                {
                    Commercials = commercials
                };
            }
            catch (TimeoutException ex)
            {
                _logger.InfoFormat(ex.Message);
            }
            catch (CommunicationException ex)
            {
                _logger.ErrorFormat(ex.Message);
            }

            return PartialView("CommercialPartial", model);
        }
    }
}