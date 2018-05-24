using Callboard.App.Business.Repositories;
using Callboard.App.General.Helpers;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class MailController : Controller
    {
        private IMailRepository _repository;
        public MailController(IMailRepository repository)
        {
            Checker.CheckForNull(repository, $"Cannot find { typeof(IMailRepository) } in App.Web MailController");
            _repository = repository;
        }

        [HttpPost]
        public JsonResult GetMailsByUserId(int userId)
        {
            Checker.CheckId(userId, $"UserId in GetMailsByUserId method is not valid.");
            var mails = _repository.GetMailsByUserId(userId);
            var mailsData = JsonConvert.SerializeObject(mails);
            return Json(mailsData, JsonRequestBehavior.AllowGet);
        }
    }
}