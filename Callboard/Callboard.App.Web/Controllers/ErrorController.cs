﻿using Callboard.App.General.Loggers.Main;
using System;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class ErrorController : Controller
    {
        private ILoggerWrapper _logger;
        public ErrorController(ILoggerWrapper logger)
        {
            if (logger == null)
            {
                throw new NullReferenceException(nameof(logger));
            }
            _logger = logger;
        }

        public ActionResult Index(string errorMessage)
        {
            _logger?.ErrorFormat(errorMessage);
            return View("Error");
        }

        public ActionResult BadRequest()
        {
            Response.StatusCode = 400;
            return View("BadRequest");
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