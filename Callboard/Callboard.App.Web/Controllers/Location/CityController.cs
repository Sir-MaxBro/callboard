using Callboard.App.Business.Services;
using Callboard.App.General.ResultExtensions;
using Callboard.App.Web.Attributes;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class CityController : Controller
    {
        private ICityService _cityProvider;
        public CityController(ICityService cityProvider)
        {
            if (cityProvider == null)
            {
                throw new NullReferenceException(nameof(cityProvider));
            }
            _cityProvider = cityProvider;
        }

        [AjaxOnly]
        public ActionResult GetCitiesByAreaId(int areaId)
        {
            var citiesResult = _cityProvider.GetCitiesByAreaId(areaId);
            if (citiesResult.IsSuccess())
            {
                var cities = citiesResult.GetSuccessResult();
                var citiesData = JsonConvert.SerializeObject(cities);
                return Json(new { Cities = citiesData }, JsonRequestBehavior.AllowGet);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }
    }
}