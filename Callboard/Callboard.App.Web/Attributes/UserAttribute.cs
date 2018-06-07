﻿using Callboard.App.Business.Auth;
using Callboard.App.General.Entities.Auth;
using System.Web;
using System.Web.Mvc;

namespace Callboard.App.Web.Attributes
{
    public class UserAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = HttpContext.Current.User;
            if (user is UserPrinciple)
            {
                return user.IsInRole(Role.User.ToString());
            }
            return false;
        }
    }
}