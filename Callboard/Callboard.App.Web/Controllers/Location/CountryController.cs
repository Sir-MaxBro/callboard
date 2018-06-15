using Callboard.App.Business.Providers.Main;
using Callboard.App.General.Helpers.Main;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class CountryController : Controller
    {
        private IChecker _checker;
        private ICountryProvider _countryProvider;
        public CountryController(ICountryProvider countryProvider, IChecker checker)
        {
            if (checker == null)
            {
                throw new NullReferenceException(nameof(checker));
            }
            _checker = checker;
            _checker.CheckForNull(countryProvider);
            _countryProvider = countryProvider;
        }

        public ActionResult GetCountries()
        {
            if (!HttpContext.Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            var countries = _countryProvider.GetAll();
            var countriesData = JsonConvert.SerializeObject(countries);
            return Json(new { Countries = countriesData }, JsonRequestBehavior.AllowGet);
        }
    }
}