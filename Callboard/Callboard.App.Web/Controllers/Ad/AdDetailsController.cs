using Callboard.App.Business.Providers.Main;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using System;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class AdDetailsController : Controller
    {
        private IChecker _checker;
        private IAdDetailsProvider _adDetailsProvider;
        public AdDetailsController(IAdDetailsProvider adDetailsProvider, IChecker checker)
        {
            if (checker == null)
            {
                throw new NullReferenceException(nameof(checker));
            }
            _checker = checker;
            _checker.CheckForNull(adDetailsProvider);
            _adDetailsProvider = adDetailsProvider;
        }

        public ActionResult GetAdDetails(int adId, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            AdDetails model = _adDetailsProvider.GetById(adId);
            return View("AdDetails", model);
        }
    }
}