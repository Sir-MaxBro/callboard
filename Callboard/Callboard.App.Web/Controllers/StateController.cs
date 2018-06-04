using Callboard.App.Business.Providers.Main;
using Callboard.App.General.Helpers.Main;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class StateController : Controller
    {
        private IChecker _checker;
        private IStateProvider _stateProvider;
        public StateController(IStateProvider stateProvider, IChecker checker)
        {
            if (checker == null)
            {
                throw new NullReferenceException(nameof(checker));
            }
            _checker = checker;
            _checker.CheckForNull(stateProvider);
            _stateProvider = stateProvider;
        }

        [HttpPost]
        public JsonResult GetStates()
        {
            var states = _stateProvider.GetStates();
            var statesData = JsonConvert.SerializeObject(states);
            return Json(new { States = statesData });
        }
    }
}