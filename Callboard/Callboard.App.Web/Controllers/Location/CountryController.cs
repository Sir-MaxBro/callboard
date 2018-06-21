using Callboard.App.Business.Services;
using Callboard.App.General.Entities;
using Callboard.App.General.ResultExtensions;
using Callboard.App.Web.Attributes;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class CountryController : Controller
    {
        private IEntityService<Country> _countryService;
        public CountryController(IEntityService<Country> countryService)
        {
            if (countryService == null)
            {
                throw new NullReferenceException(nameof(countryService));
            }
            _countryService = countryService;
        }

        [AjaxOnly]
        public ActionResult GetCountries()
        {
            var countriesResult = _countryService.GetAll();
            if (countriesResult.IsSuccess())
            {
                var countries = countriesResult.GetSuccessResult();
                var countriesData = JsonConvert.SerializeObject(countries);
                return Json(new { Countries = countriesData }, JsonRequestBehavior.AllowGet);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        [Editor]
        public ActionResult GetCountryEditList()
        {
            var countriesResult = _countryService.GetAll();
            if (countriesResult.IsSuccess())
            {
                var countries = countriesResult.GetSuccessResult();
                return PartialView("CountryEditList", countries);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        [Editor]
        [AjaxOnly]
        [HttpPost]
        public ActionResult SaveCountry(string countryData)
        {
            countryData = countryData ?? string.Empty;
            var country = JsonConvert.DeserializeObject<Country>(countryData);
            if (country != null)
            {
                var countrySaveResult = _countryService.Save(country);
                if (countrySaveResult.IsNone())
                {
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [Editor]
        [AjaxOnly]
        [HttpPost]
        public ActionResult DeleteCountry(int countryId)
        {
            var countryDeleteResult = _countryService.Delete(countryId);
            if (countryDeleteResult.IsNone())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}