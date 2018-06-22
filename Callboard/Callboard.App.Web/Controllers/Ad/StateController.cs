using Callboard.App.Business.Services;
using Callboard.App.General.Entities;
using Callboard.App.General.ResultExtensions;
using Callboard.App.Web.Attributes;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class StateController : Controller
    {
        private IEntityService<State> _stateService;
        public StateController(IEntityService<State> stateService)
        {
            if (stateService == null)
            {
                throw new NullReferenceException(nameof(stateService));
            }
            _stateService = stateService;
        }

        [AjaxOnly]
        public ActionResult GetStates()
        {
            var statesResult = _stateService.GetAll();
            if (statesResult.IsSuccess())
            {
                var states = statesResult.GetSuccessResult();
                var statesData = JsonConvert.SerializeObject(states);
                return Json(new { States = statesData }, JsonRequestBehavior.AllowGet);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        [Editor]
        public ActionResult GetStateEditList()
        {
            var statesResult = _stateService.GetAll();
            if (statesResult.IsSuccess())
            {
                var states = statesResult.GetSuccessResult();
                return PartialView("StateEditList", states);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        [Editor]
        [AjaxOnly]
        [HttpPost]
        public ActionResult SaveState(string stateData)
        {
            stateData = stateData ?? string.Empty;
            var state = JsonConvert.DeserializeObject<State>(stateData);
            if (state != null)
            {
                var stateSaveResult = _stateService.Save(state);
                if (stateSaveResult.IsNone())
                {
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [Editor]
        [AjaxOnly]
        [HttpPost]
        public ActionResult DeleteState(int stateId)
        {
            var stateDeleteResult = _stateService.Delete(stateId);
            if (stateDeleteResult.IsNone())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}