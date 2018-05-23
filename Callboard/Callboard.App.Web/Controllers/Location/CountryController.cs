using Callboard.App.Business.Repositories;
using Callboard.App.General.Helpers;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class CountryController : Controller
    {
        private ICountryRepository _repository;
        public CountryController(ICountryRepository repository)
        {
            Checker.CheckForNull(repository, $"Cannot find { typeof(ICountryRepository) } in App.Web CountryController");
            _repository = repository;
        }

        public JsonResult GetCountries()
        {
            var countries = _repository.GetCountries();
            var countriesData = JsonConvert.SerializeObject(countries);
            return Json(countriesData, JsonRequestBehavior.AllowGet);
        }
    }
}