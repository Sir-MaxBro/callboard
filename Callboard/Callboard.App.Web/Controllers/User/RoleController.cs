using Callboard.App.Business.Services;
using Callboard.App.General.ResultExtensions;
using Callboard.App.Web.Attributes;
using Callboard.App.Web.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class RoleController : Controller
    {
        private IRoleService _roleProvider;
        public RoleController(IRoleService roleProvider)
        {
            if (roleProvider == null)
            {
                throw new NullReferenceException(nameof(roleProvider));
            }
            _roleProvider = roleProvider;
        }

        [Admin]
        [AjaxOnly]
        public ActionResult GetRoles()
        {
            var rolesResult = _roleProvider.GetAll();
            if (rolesResult.IsSuccess())
            {
                var roles = rolesResult.GetSuccessResult();
                var rolesData = JsonConvert.SerializeObject(roles);
                return Json(new { Roles = rolesData }, JsonRequestBehavior.AllowGet);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        [Admin]
        public ActionResult GetRolesEditList(int userId)
        {
            var rolesResult = _roleProvider.GetRolesForUser(userId);
            if (rolesResult.IsSuccess())
            {
                var roles = rolesResult.GetSuccessResult();
                var rolesModel = new UserRoleEditViewModel
                {
                    Roles = roles,
                    UserId = userId
                };
                return PartialView("UserRoleEditList", rolesModel);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        [Admin]
        [HttpPost]
        public ActionResult SetRoleForUser(int userId, int roleId)
        {
            var rolesResult = _roleProvider.SetRoleForUser(userId, roleId);
            if (rolesResult.IsNone())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [Admin]
        [HttpPost]
        public ActionResult DeleteUserRole(int userId, int roleId)
        {
            var rolesResult = _roleProvider.DeleteUserRole(userId, roleId);
            if (rolesResult.IsNone())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}