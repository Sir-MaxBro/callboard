using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return View("Error");
        }

        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View("NotFound");
        }

        public ActionResult ServerNotResponding()
        {
            Response.StatusCode = 500; 
            return View("ServerNotResponding");
        }
    }
}