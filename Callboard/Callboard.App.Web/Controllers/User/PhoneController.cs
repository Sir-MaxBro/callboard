using Callboard.App.Business.Repositories;
using Callboard.App.General.Helpers;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class PhoneController : Controller
    {
        private IPhoneRepository _repository;
        public PhoneController(IPhoneRepository repository)
        {
            Checker.CheckForNull(repository, $"Cannot find { typeof(IPhoneRepository) } in App.Web PhoneController");
            _repository = repository;
        }

        public PartialViewResult GetPhonesByUserId(int userId)
        {
            Checker.CheckId(userId, $"UserId in GetPhonesByUserId method is not valid.");
            var model = _repository.GetPhonesByUserId(userId);
            return PartialView(model);
        }
    }
}