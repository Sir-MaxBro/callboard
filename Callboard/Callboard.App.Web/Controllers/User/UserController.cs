using Callboard.App.Business.Services;
using Callboard.App.General.Entities;
using Callboard.App.General.Entities.Auth;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.ResultExtensions;
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

        public ActionResult GetUser(int userId)
        {
            var userResult = _userProvider.GetById(userId);
            if (userResult.IsSuccess())
            {
                var user = userResult.GetSuccessResult();
                return PartialView("User", user);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        [User]
        public ActionResult OpenProfile(int userId)
        {
            var userPrinciple = User as UserPrinciple;
            if (userPrinciple.UserId == userId || userPrinciple.IsInRole(Business.Auth.Role.Admin.ToString()))
            {
                var userResult = _userProvider.GetById(userId);
                if (userResult.IsSuccess())
                {
                    var user = userResult.GetSuccessResult();
                    return View("UserProfile", user);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        [User]
        public ActionResult EditProfile(int userId, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            var userPrinciple = User as UserPrinciple;
            if (userPrinciple.UserId == userId || userPrinciple.IsInRole(Business.Auth.Role.Admin.ToString()))
            {
                var userResult = _userProvider.GetById(userId);
                if (userResult.IsSuccess())
                {
                    var user = userResult.GetSuccessResult();
                    var userModel = new UserViewModel { User = user };
                    return View("EditProfile", userModel);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        [User]
        public ActionResult EditUser(int userId)
        {
            var userPrinciple = User as UserPrinciple;
            if (userPrinciple.UserId == userId || userPrinciple.IsInRole(Business.Auth.Role.Admin.ToString()))
            {
                var userResult = _userProvider.GetById(userId);
                if (userResult.IsSuccess())
                {
                    var user = userResult.GetSuccessResult();
                    return PartialView("UserEdit", user);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        [User]
        [AjaxOnly]
        [HttpPost]
        public ActionResult SaveUser(string userData)
        {
            var user = JsonConvert.DeserializeObject<User>(userData);
            if (user != null)
            {
                var userSaveResult = _userProvider.Save(user);
                if (userSaveResult.IsNone())
                {
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [Admin]
        public ActionResult GetAllUsers()
        {
            var usersResult = _userProvider.GetAll();
            if (usersResult.IsSuccess())
            {
                var users = usersResult.GetSuccessResult();
                return View("UserList", users);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        [Admin]
        [HttpPost]
        public ActionResult DeleteUserById(int userId)
        {
            var userDeleteResult = _userProvider.Delete(userId);
            if (userDeleteResult.IsNone())
            {
                return RedirectToAction("GetAllUsers");
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}