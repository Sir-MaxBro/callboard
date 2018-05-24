using Callboard.App.Business.Repositories;
using Callboard.App.General.Helpers;
using Newtonsoft.Json;
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

        [HttpPost]
        public JsonResult GetPhonesByUserId(int userId)
        {
            Checker.CheckId(userId, $"UserId in GetPhonesByUserId method is not valid.");
            var phones = _repository.GetPhonesByUserId(userId);
            var phonesData = JsonConvert.SerializeObject(phones);
            return Json(phonesData, JsonRequestBehavior.AllowGet);
        }
    }
}