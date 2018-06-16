using Callboard.App.Business.Services;
using Callboard.App.General.Helpers.Main;
using Callboard.App.Web.Attributes;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class RoleController : Controller
    {
        private IRoleService _roleProvider;
        private IChecker _checker;
        public RoleController(IRoleService roleProvider, IChecker checker)
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
        public ActionResult GetRoles()
        {
            if (!HttpContext.Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            var roles = _roleProvider.GetAll();
            var rolesData = JsonConvert.SerializeObject(roles);
            return Json(new { Roles = rolesData }, JsonRequestBehavior.AllowGet);
        }

        [Admin]
        public ActionResult GetRolesForUser(int userId)
        {
            if (!HttpContext.Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

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