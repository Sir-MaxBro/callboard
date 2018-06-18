using Callboard.App.Business.Services;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.ResultExtensions;
using Callboard.App.Web.Models;
using System;
using System.Net;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class AccountController : Controller
    {
        private ILogginService _logginService;
        private IChecker _checker;
        public AccountController(ILogginService logginService, IChecker checker)
        {
            if (checker == null)
            {
                throw new NullReferenceException(nameof(checker));
            }
            _checker = checker;
            _checker.CheckForNull(logginService);
            _logginService = logginService;
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var logginResult = _logginService.Login(model.Login, model.Password);

            if (logginResult.IsFailure())
            {
                ViewBag.ErrorMessage = logginResult.GetFailureMessage();
                return View(model);
            }

            returnUrl = Url.IsLocalUrl(returnUrl) ? returnUrl : "/Home/Index";
            return Redirect(returnUrl);
        }

        public ActionResult Register(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var logginResult = _logginService.Register(model.Login, model.Password);

            if (logginResult.IsFailure())
            {
                ViewBag.ErrorMessage = logginResult.GetFailureMessage();
                return View(model);
            }

            returnUrl = Url.IsLocalUrl(returnUrl) ? returnUrl : "/Home/Index";
            return Redirect(returnUrl);
        }

        public ActionResult Logout()
        {
            var logginResult = _logginService.Logout();
            if (logginResult.IsNone())
            {
                return RedirectToAction("Login", "Account");
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}