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
    public class CityController : Controller
    {
        private ICityService _cityService;
        public CityController(ICityService cityService)
        {
            if (cityService == null)
            {
                throw new NullReferenceException(nameof(cityService));
            }
            _cityService = cityService;
        }

        [AjaxOnly]
        public ActionResult GetCitiesByAreaId(int areaId)
        {
            var citiesResult = _cityService.GetCitiesByAreaId(areaId);
            if (citiesResult.IsSuccess())
            {
                var cities = citiesResult.GetSuccessResult();
                var citiesData = JsonConvert.SerializeObject(cities);
                return Json(new { Cities = citiesData }, JsonRequestBehavior.AllowGet);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        [Editor]
        public ActionResult GetCityEditListByAreaId(int areaId)
        {
            var citiesResult = _cityService.GetCitiesByAreaId(areaId);
            if (citiesResult.IsSuccess())
            {
                var cities = citiesResult.GetSuccessResult();
                var cityListModel = new CityListViewModel
                {
                    AreaId = areaId,
                    Cities = cities
                };

                return PartialView("CityEditList", cityListModel);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        [Editor]
        [AjaxOnly]
        [HttpPost]
        public ActionResult DeleteCity(int cityId)
        {
            var cityDeleteResult = _cityService.Delete(cityId);
            if (cityDeleteResult.IsNone())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [Editor]
        [AjaxOnly]
        [HttpPost]
        public ActionResult SaveCity(string cityViewModelData)
        {
            cityViewModelData = cityViewModelData ?? string.Empty;
            var cityViewModel = JsonConvert.DeserializeObject<CityViewModel>(cityViewModelData);
            if (cityViewModel != null)
            {
                var citySaveResult = _cityService.Save(cityViewModel.AreaId, cityViewModel.City);
                if (citySaveResult.IsNone())
                {
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}