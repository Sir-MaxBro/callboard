using Callboard.App.Business.Providers.Main;
using Callboard.App.General.Helpers.Main;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class KindController : Controller
    {
        private IKindProvider _kindProvider;
        private IChecker _checker;
        public KindController(IKindProvider kindProvider, IChecker checker)
        {
            if (checker == null)
            {
                throw new NullReferenceException(nameof(checker));
            }
            _checker = checker;
            _checker.CheckForNull(kindProvider);
            _kindProvider = kindProvider;
        }

        public JsonResult GetKinds()
        {
            var kinds = _kindProvider.GetAll();
            var kindsData = JsonConvert.SerializeObject(kinds);
            return Json(new { Kinds = kindsData }, JsonRequestBehavior.AllowGet);
        }
    }
}