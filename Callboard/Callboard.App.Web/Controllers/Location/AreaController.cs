using Callboard.App.Business.Repositories;
using Callboard.App.General.Helpers;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class AreaController : Controller
    {
        private IAreaRepository _repository;
        public AreaController(IAreaRepository repository)
        {
            Checker.CheckForNull(repository, $"Cannot find { typeof(IAreaRepository) } in App.Web AreaController");
            _repository = repository;
        }

        public JsonResult GetAreasByCountryId(int countryId)
        {
            Checker.CheckId(countryId, $"CountryId in GetAreasByCountryId method is not valid.");
            var areas = _repository.GetAreasByCountryId(countryId);
            var areasData = JsonConvert.SerializeObject(areas);
            return Json(areasData, JsonRequestBehavior.AllowGet);
        }
    }
}