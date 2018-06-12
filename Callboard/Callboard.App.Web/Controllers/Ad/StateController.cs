using Callboard.App.Business.Providers.Main;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using Callboard.App.Web.Attributes;
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

        public JsonResult GetStates()
        {
            var states = _stateProvider.GetAll();
            var statesData = JsonConvert.SerializeObject(states);
            return Json(new { States = statesData }, JsonRequestBehavior.AllowGet);
        }

        [Editor]
        [HttpPost]
        public JsonResult SaveState(string stateData)
        {
            bool isSaved = false;
            stateData = stateData ?? string.Empty;
            var state = JsonConvert.DeserializeObject<State>(stateData);
            if (state != null)
            {
                _stateProvider.Save(state);
                isSaved = true;
            }
            return Json(new { IsSaved = isSaved });
        }

        [Editor]
        [HttpPost]
        public JsonResult DeleteState(int stateId)
        {
            _stateProvider.Delete(stateId);
            return Json(new { IdDeleted = true });
        }
    }
}