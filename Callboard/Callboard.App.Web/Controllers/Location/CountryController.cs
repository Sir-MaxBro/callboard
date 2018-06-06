using Callboard.App.Business.Providers.Main;
using Callboard.App.General.Helpers.Main;
using Newtonsoft.Json;
using System;
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

        [HttpPost]
        public JsonResult GetCountries()
        {
            var countries = _countryProvider.GetAll();
            var countriesData = JsonConvert.SerializeObject(countries);
            return Json(new { Countries = countriesData }, JsonRequestBehavior.AllowGet);
        }
    }
}