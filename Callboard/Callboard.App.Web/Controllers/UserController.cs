using Callboard.App.Business.Repositories;
using Callboard.App.General.Helpers;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            Checker.CheckForNull(repository, $"Cannot find { typeof(IUserRepository) } in App.Web UserController");
            _repository = repository;
        }

        public PartialViewResult GetUser(int userId)
        {
            var user = _repository.GetUserById(userId);
            return PartialView("User", user);
        }
    }
}