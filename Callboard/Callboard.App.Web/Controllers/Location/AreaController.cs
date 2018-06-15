using Callboard.App.Business.Providers.Main;
using Callboard.App.General.Helpers.Main;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class AreaController : Controller
    {
        private IChecker _checker;
        private IAreaProvider _areaProvider;
        public AreaController(IAreaProvider areaProvider, IChecker checker)
        {
            if (checker == null)
            {
                throw new NullReferenceException(nameof(checker));
            }
            _checker = checker;
            _areaProvider = areaProvider;
        }

        public ActionResult GetAreasByCountryId(int countryId)
        {
            if (!HttpContext.Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            var areas = _areaProvider.GetAreasByCountryId(countryId);
            var areasData = JsonConvert.SerializeObject(areas);
            return Json(new { Areas = areasData }, JsonRequestBehavior.AllowGet);
        }
    }
}