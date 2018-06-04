using Callboard.App.General.Entities.Auth;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Auth = Callboard.App.General.Entities.Auth;

namespace Callboard.App.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs arg)
        {
            var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie != null)
            {
                try
                {
                    var ticket = FormsAuthentication.Decrypt(cookie.Value);
                    var user = JsonConvert.DeserializeObject<Auth::MembershipUser>(ticket.UserData);
                    var userPrinciple = new UserPrinciple(user.Name)
                    {
                        UserId = user.UserId,
                        Name = user.Name,
                        Roles = user.Roles.Select(x => x.Name).ToArray()
                    };
                    HttpContext.Current.User = userPrinciple;
                }
                catch (System.Security.Cryptography.CryptographicException ex)
                {

                }
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Response.Clear();
            HttpException httpException = exception as HttpException;
            if (httpException != null)
            {
                Server.ClearError();
                Response.Redirect($"~/Error/Index/?errorMessage={ exception.Message }");
            }
        }
    }
}
