using Callboard.App.Business.Providers.Main;
using Callboard.App.General.Helpers.Main;
using Callboard.App.Web.Attributes;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class RoleController : Controller
    {
        private IRoleProvider _roleProvider;
        private IChecker _checker;
        public RoleController(IRoleProvider roleProvider, IChecker checker)
        {
            if (checker == null)
            {
                throw new NullReferenceException(nameof(checker));
            }
            _checker = checker;
            _checker.CheckForNull(roleProvider);
            _roleProvider = roleProvider;
        }

        [Admin]
        public JsonResult GetRoles()
        {
            var roles = _roleProvider.GetAll();
            var rolesData = JsonConvert.SerializeObject(roles);
            return Json(new { Roles = rolesData }, JsonRequestBehavior.AllowGet);
        }

        [Admin]
        public JsonResult GetRolesForUser(int userId)
        {
            var roles = _roleProvider.GetRolesForUser(userId);
            var rolesData = JsonConvert.SerializeObject(roles);
            return Json(new { Roles = rolesData }, JsonRequestBehavior.AllowGet);
        }

        [Admin]
        [HttpPost]
        public ActionResult SetRoleForUser(int userId, int roleId)
        {
            _roleProvider.SetRoleForUser(userId, roleId);
            return RedirectToAction("GetRolesForUser", new { userId });
        }

        [Admin]
        [HttpPost]
        public ActionResult DeleteUserRole(int userId, int roleId)
        {
            _roleProvider.DeleteUserRole(userId, roleId);
            return RedirectToAction("GetRolesForUser", new { userId });
        }
    }
}