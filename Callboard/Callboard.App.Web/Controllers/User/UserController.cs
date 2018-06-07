using Callboard.App.Business.Providers.Main;
using Callboard.App.General.Helpers.Main;
using Callboard.App.Web.Attributes;
using System;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class UserController : Controller
    {
        private IChecker _checker;
        private IUserProvider _userProvider;
        public UserController(IUserProvider userProvider, IChecker checker)
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

        [Admin]
        public ActionResult GetAllUser()
        {
            var users = _userProvider.GetAll();
            return View("UserList", users);
        }

        [Admin]
        [HttpPost]
        public JsonResult DeleteUserById(int userId)
        {
            _userProvider.Delete(userId);
            return Json(new { IsDeleted = true });
        }
    }
}