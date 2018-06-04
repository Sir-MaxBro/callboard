using Callboard.App.Business.Services;
using Callboard.App.General.Helpers.Main;
using Callboard.App.Web.Models;
using System;
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
            _logginService.Login(model.Login, model.Password);
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public RedirectToRouteResult Logout()
        {
            _logginService.Logout();
            return RedirectToAction("Login");
        }
    }
}