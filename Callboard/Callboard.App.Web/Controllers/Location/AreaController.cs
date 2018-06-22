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
    public class AreaController : Controller
    {
        private IAreaService _areaService;
        public AreaController(IAreaService areaService)
        {
            if (areaService == null)
            {
                throw new NullReferenceException(nameof(areaService));
            }
            _areaService = areaService;
        }

        [AjaxOnly]
        public ActionResult GetAreasByCountryId(int countryId)
        {
            var areasResult = _areaService.GetAreasByCountryId(countryId);
            if (areasResult.IsSuccess())
            {
                var areas = areasResult.GetSuccessResult();
                var areasData = JsonConvert.SerializeObject(areas);
                return Json(new { Areas = areasData }, JsonRequestBehavior.AllowGet);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        [Editor]
        public ActionResult GetAreaEditListByCountryId(int countryId)
        {
            var areasResult = _areaService.GetAreasByCountryId(countryId);
            if (areasResult.IsSuccess())
            {
                var areas = areasResult.GetSuccessResult();
                var areaModel = new AreaListViewModel
                {
                    CountryId = countryId,
                    Areas = areas
                };

                return PartialView("AreaEditList", areaModel);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        [Editor]
        [AjaxOnly]
        [HttpPost]
        public ActionResult DeleteArea(int areaId)
        {
            var areaDeleteResult = _areaService.Delete(areaId);
            if (areaDeleteResult.IsNone())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [Editor]
        [AjaxOnly]
        [HttpPost]
        public ActionResult SaveArea(string areaViewModelData)
        {
            areaViewModelData = areaViewModelData ?? string.Empty;
            var areaViewModel = JsonConvert.DeserializeObject<AreaViewModel>(areaViewModelData);
            if (areaViewModel != null)
            {
                var areaSaveResult = _areaService.Save(areaViewModel.CountryId, areaViewModel.Area);
                if (areaSaveResult.IsNone())
                {
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}