using Callboard.App.Business.Services;
using Callboard.App.General.Entities;
using Callboard.App.General.Entities.Auth;
using Callboard.App.General.Helpers.Main;
using Callboard.App.Web.Attributes;
using Callboard.App.Web.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class UserController : Controller
    {
        private IChecker _checker;
        private IEntityService<User> _userProvider;
        public UserController(IEntityService<User> userProvider, IChecker checker)
        {
            if (checker == null)
            {
                throw new NullReferenceException(nameof(checker));
            }
            _checker = checker;
            _checker.CheckForNull(userProvider);
            _userProvider = userProvider;
        }

        public PartialViewResult GetUser(int userId)
        {
            var user = _userProvider.GetById(userId);
            return PartialView("User", user);
        }

        [User]
        public ActionResult OpenProfile(int userId)
        {
            var userPrinciple = User as UserPrinciple;
            if (userPrinciple.UserId == userId || userPrinciple.IsInRole(Business.Auth.Role.Admin.ToString()))
            {
                var user = _userProvider.GetById(userId);
                return View("UserProfile", user);
            }
            else
            {
                return RedirectToAction("Error", "Error");
            }
        }

        [User]
        public ActionResult EditProfile(int userId, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            var userPrinciple = User as UserPrinciple;
            if (userPrinciple.UserId == userId || userPrinciple.IsInRole(Business.Auth.Role.Admin.ToString()))
            {
                var user = _userProvider.GetById(userId);
                var userModel = new UserViewModel
                {
                    User = user
                };
                return View("EditProfile", userModel);
            }
            else
            {
                return RedirectToAction("Error", "Error");
            }
        }

        [User]
        public ActionResult EditUser(int userId)
        {
            var userPrinciple = User as UserPrinciple;
            if (userPrinciple.UserId == userId || userPrinciple.IsInRole(Business.Auth.Role.Admin.ToString()))
            {
                var user = _userProvider.GetById(userId);
                return PartialView("UserEdit", user);
            }
            else
            {
                return RedirectToAction("Error", "Error");
            }
        }

        [User]
        [HttpPost]
        public ActionResult SaveUser(string userData)
        {
            if (!HttpContext.Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            bool isSaved = false;
            var user = JsonConvert.DeserializeObject<User>(userData);
            if (user != null)
            {
                _userProvider.Save(user);
                isSaved = true;
            }
            return Json(new { IsSaved = isSaved });
        }

        [Admin]
        public ActionResult GetAllUsers()
        {
            var users = _userProvider.GetAll();
            return View("UserList", users);
        }

        [Admin]
        [HttpPost]
        public ActionResult DeleteUserById(int userId)
        {
            _userProvider.Delete(userId);
            return RedirectToAction("GetAllUsers");
        }
    }
}