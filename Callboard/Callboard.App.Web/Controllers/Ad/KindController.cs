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
    public class KindController : Controller
    {
        private IEntityService<Kind> _kindService;
        public KindController(IEntityService<Kind> kindService)
        {
            if (kindService == null)
            {
                throw new NullReferenceException(nameof(kindService));
            }
            _kindService = kindService;
        }

        [AjaxOnly]
        public ActionResult GetKinds()
        {
            var kindsResult = _kindService.GetAll();
            if (kindsResult.IsSuccess())
            {
                var kinds = kindsResult.GetSuccessResult();
                var kindsData = JsonConvert.SerializeObject(kinds);
                return Json(new { Kinds = kindsData }, JsonRequestBehavior.AllowGet);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        [Editor]
        public ActionResult GetKindEditList()
        {
            var kindsResult = _kindService.GetAll();
            if (kindsResult.IsSuccess())
            {
                var kinds = kindsResult.GetSuccessResult();
                return PartialView("KindEditList", kinds);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        [Editor]
        [AjaxOnly]
        [HttpPost]
        public ActionResult SaveKind(string kindData)
        {
            kindData = kindData ?? string.Empty;
            var kind = JsonConvert.DeserializeObject<Kind>(kindData);
            if (kind != null)
            {
                var kindSaveResult = _kindService.Save(kind);
                if (kindSaveResult.IsNone())
                {
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [Editor]
        [AjaxOnly]
        [HttpPost]
        public ActionResult DeleteKind(int kindId)
        {
            var kindDeleteResult = _kindService.Delete(kindId);
            if (kindDeleteResult.IsNone())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}