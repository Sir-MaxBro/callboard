using Callboard.App.Business.Repositories;
using Callboard.App.General.Helpers;
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

        public PartialViewResult GetMailsByUserId(int userId)
        {
            Checker.CheckId(userId, $"UserId in GetMailsByUserId method is not valid.");
            var model = _repository.GetMailsByUserId(userId);
            return PartialView(model);
        }
    }
}