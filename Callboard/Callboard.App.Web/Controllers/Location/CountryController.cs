using Callboard.App.Business.Services;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
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
        private IChecker _checker;
        private IEntityService<Country> _countryProvider;
        public CountryController(IEntityService<Country> countryProvider, IChecker checker)
        {
            if (checker == null)
            {
                throw new NullReferenceException(nameof(checker));
            }
            _checker = checker;
            _checker.CheckForNull(countryProvider);
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