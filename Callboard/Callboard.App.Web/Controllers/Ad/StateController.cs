using Callboard.App.Business.Services;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using Callboard.App.Web.Attributes;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class StateController : Controller
    {
        private IChecker _checker;
        private IEntityService<State> _stateProvider;
        public StateController(IEntityService<State> stateProvider, IChecker checker)
        {
            if (checker == null)
            {
                throw new NullReferenceException(nameof(checker));
            }
            _checker = checker;
            _checker.CheckForNull(stateProvider);
            _stateProvider = stateProvider;
        }

        public ActionResult GetStates()
        {
            if (!HttpContext.Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            var states = _stateProvider.GetAll();
            var statesData = JsonConvert.SerializeObject(states);
            return Json(new { States = statesData }, JsonRequestBehavior.AllowGet);
        }

        [Editor]
        [HttpPost]
        public ActionResult SaveState(string stateData)
        {
            if (!HttpContext.Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

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
        public ActionResult DeleteState(int stateId)
        {
            if (!HttpContext.Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            _stateProvider.Delete(stateId);
            return Json(new { IdDeleted = true });
        }
    }
}