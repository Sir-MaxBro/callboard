using Callboard.App.Business.Repositories;
using Callboard.App.General.Helpers;
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

        public PartialViewResult GetCity(int cityId)
        {
            Checker.CheckId(cityId, $"CityId in GetCity method is not valid.");
            var model = _repository.GetCity(cityId);
            return PartialView(model);
        }
    }
}