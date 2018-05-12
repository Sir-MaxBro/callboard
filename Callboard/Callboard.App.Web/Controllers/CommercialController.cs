using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Callboard.App.Web.CommercialService;

namespace Callboard.App.Web.Controllers
{
    public class CommercialController : Controller
    {
        // GET: Commercial
        public ActionResult GetCommercial()
        {
            ICommercialRepository commercialRepository = new CommercialRepositoryClient();

            var commercials = commercialRepository.GetCommercials();

            return View();
        }
    }
}