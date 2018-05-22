using Callboard.App.Business.Repositories;
using Callboard.App.General.Entities;
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

        public PartialViewResult GetLocationByCityId(int cityId)
        {
            Checker.CheckId(cityId, $"CityId in GetLocationByCityId method is not valid.");
            Location location = _repository.GetLocationByCityId(cityId);
            return PartialView("Location", location);
        }
    }
}