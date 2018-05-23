using Callboard.App.Business.Repositories;
using Callboard.App.General.Helpers;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class CityController : Controller
    {
        private ICityRepository _repository;
        public CityController(ICityRepository repository)
        {
            Checker.CheckForNull(repository, $"Cannot find { typeof(ICityRepository) } in App.Web CityController");
            _repository = repository;
        }

        public JsonResult GetCitiesByAreaId(int areaId)
        {
            Checker.CheckId(areaId, $"AreaId in GetCitiesByAreaId method is not valid.");
            var cities = _repository.GetCitiesByAreaId(areaId);
            var model = JsonConvert.SerializeObject(cities);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}