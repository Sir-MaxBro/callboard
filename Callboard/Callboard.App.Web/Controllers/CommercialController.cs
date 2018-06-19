using Callboard.App.Business.Services;
using Callboard.App.General.Entities.Commercial;
using Callboard.App.General.ResultExtensions;
using Callboard.App.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class CommercialController : Controller
    {
        private ICommercialService _commercialProvider;
        public CommercialController(ICommercialService commercialProvider)
        {
            if (commercialProvider == null)
            {
                throw new NullReferenceException(nameof(commercialProvider));
            }
            _commercialProvider = commercialProvider;
        }

        public ActionResult GetCommercial()
        {
            IReadOnlyCollection<Commercial> commercials = new List<Commercial>();

            var commercialResult = _commercialProvider.GetCommercials();
            if (commercialResult.IsSuccess())
            {
                commercials = commercialResult.GetSuccessResult();
            }

            var model = new CommercialViewModel { Commercials = commercials };
            return PartialView("CommercialPartial", model);
        }
    }
}