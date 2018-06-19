using Callboard.App.Business.Services;
using Callboard.App.General.ResultExtensions;
using Callboard.App.Web.Attributes;
using Callboard.App.Web.Models;
using System;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class MembershipController : Controller
    {
        private IMembershipService _membershipProvider;
        public MembershipController(IMembershipService membershipProvider)
        {
            if (membershipProvider == null)
            {
                throw new NullReferenceException(nameof(membershipProvider));
            }
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
            if (!ModelState.IsValid)
            {
                return RedirectToAction("CreateUser", registerModel);
            }

            var membershipResult = _membershipProvider.CreateUser(registerModel.Login, registerModel.Password);
            if (membershipResult.IsFailure())
            {
                ViewBag.ErrorMessage = membershipResult.GetFailureMessage();
                return RedirectToAction("CreateUser", registerModel);
            }
            return RedirectToAction("GetAllUsers", "User");
        }
    }
}