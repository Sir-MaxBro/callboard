﻿using Callboard.App.General.Loggers.Main;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class ErrorController : Controller
    {
        private ILoggerWrapper _logger;
        public ErrorController(ILoggerWrapper logger)
        {
            _logger = logger;
        }

        public ActionResult Index(string errorMessage)
        {
            _logger?.ErrorFormat(errorMessage);
            return View("Error");
        }

        public ActionResult PageNotFound()
        {
            Response.StatusCode = 404;
            return View("NotFoundPage");
        }

        public ActionResult ServerNotResponding()
        {
            Response.StatusCode = 500; 
            return View("ServerNotRespondingPage");
        }
    }
}