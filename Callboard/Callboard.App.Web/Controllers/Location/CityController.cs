using Callboard.App.Business.Providers.Main;
using Callboard.App.General.Helpers.Main;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class CityController : Controller
    {
        private IChecker _checker;
        private ICityProvider _cityProvider;
        public CityController(ICityProvider cityProvider, IChecker checker)
        {
            if (checker == null)
            {
                throw new NullReferenceException(nameof(checker));
            }
            _checker = checker;
            _checker.CheckForNull(cityProvider);
            _cityProvider = cityProvider;
        }

        public JsonResult GetCitiesByAreaId(int areaId)
        {
            var cities = _cityProvider.GetCitiesByAreaId(areaId);
            var citiesData = JsonConvert.SerializeObject(cities);
            return Json(new { Cities = citiesData }, JsonRequestBehavior.AllowGet);
        }
    }
}