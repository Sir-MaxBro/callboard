using Callboard.App.Business.Services;
using Callboard.App.General.ResultExtensions;
using Callboard.App.Web.Attributes;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class AreaController : Controller
    {
        private IAreaService _areaProvider;
        public AreaController(IAreaService areaProvider)
        {
            if (areaProvider == null)
            {
                throw new NullReferenceException(nameof(areaProvider));
            }
            _areaProvider = areaProvider;
        }

        [AjaxOnly]
        public ActionResult GetAreasByCountryId(int countryId)
        {
            var areasResult = _areaProvider.GetAreasByCountryId(countryId);
            if (areasResult.IsSuccess())
            {
                var areas = areasResult.GetSuccessResult();
                var areasData = JsonConvert.SerializeObject(areas);
                return Json(new { Areas = areasData }, JsonRequestBehavior.AllowGet);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }
    }
}