using Callboard.App.Web.Attributes;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class EditorController : Controller
    {
        [Editor]
        public ActionResult OpenEditorPage()
        {
            return View("EditorPage");
        }
    }
}