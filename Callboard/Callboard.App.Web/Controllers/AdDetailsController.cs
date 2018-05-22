using Callboard.App.Business.Repositories;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class AdDetailsController : Controller
    {
        private IAdDetailsRepository _repository;
        public AdDetailsController(IAdDetailsRepository repository)
        {
            Checker.CheckForNull(repository);
            _repository = repository;
        }

        public ActionResult GetAdDetails(int adId)
        {
            AdDetails model = _repository.GetAdDetails(adId);
            return View("AdDetails", model);
        }
    }
}