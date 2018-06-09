using Callboard.App.Business.Providers.Main;
using Callboard.App.General.Helpers.Main;
using Callboard.App.Web.Attributes;
using Callboard.App.Web.Models;
using System;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class MembershipController : Controller
    {
        private IMembershipProvider _membershipProvider;
        private IChecker _checker;
        public MembershipController(IMembershipProvider membershipProvider, IChecker checker)
        {
            if (checker == null)
            {
                throw new NullReferenceException(nameof(checker));
            }
            _checker = checker;
            _checker.CheckForNull(membershipProvider);
            _membershipProvider = membershipProvider;
        }

        [Admin]
        public ActionResult CreateUser(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new RegisterViewModel());
        }

        [Admin]
        [HttpPost]
        public ActionResult CreateUser(RegisterViewModel registerModel, string returnUrl)
        {
            if (registerModel != null)
            {
                _membershipProvider.CreateUser(registerModel.Login, registerModel.Password);
            }
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("GetAllUsers", "User");
            }
        }
    }
}