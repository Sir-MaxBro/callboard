using Callboard.App.General.Entities.Auth;
using System.Web;
using System.Web.Mvc;

namespace Callboard.App.Web.Attributes
{
    public class AdminAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = HttpContext.Current.User;
            if (user is UserPrinciple)
            {
                return user.IsInRole("admin");
            }
            return false;
        }
    }
}
