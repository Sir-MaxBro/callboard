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
        private IEntityService<Country> _countryProvider;
        public CountryController(IEntityService<Country> countryProvider)
        {
            if (countryProvider == null)
            {
                throw new NullReferenceException(nameof(countryProvider));
            }
            _countryProvider = countryProvider;
        }

        [AjaxOnly]
        public ActionResult GetCountries()
        {
            var countriesResult = _countryProvider.GetAll();
            if (countriesResult.IsSuccess())
            {
                var countries = countriesResult.GetSuccessResult();
                var countriesData = JsonConvert.SerializeObject(countries);
                return Json(new { Countries = countriesData }, JsonRequestBehavior.AllowGet);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }
    }
}