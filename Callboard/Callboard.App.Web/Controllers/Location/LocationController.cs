using Callboard.App.Business.Repositories;
using Callboard.App.General.Helpers;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class LocationController : Controller
    {
        private ILocationRepository _repository;
        public LocationController(ILocationRepository repository)
        {
            Checker.CheckForNull(repository, $"Cannot find { typeof(ILocationRepository) } in App.Web LocationController");
            _repository = repository;
        }

        [HttpPost]
        public PartialViewResult GetLocationByCityId(int cityId)
        {
            Checker.CheckId(cityId, $"CityId in GetLocationByCityId method is not valid.");
            var location = _repository.GetLocationByCityId(cityId);
            return PartialView("Location", location);
        }
    }
}