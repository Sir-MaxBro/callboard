using Callboard.App.Business.Providers.Main;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using Callboard.App.Web.Attributes;
using Callboard.App.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [User]
        public ActionResult EditAdDetails(int adId)
        {
            var adDetails = _adDetailsProvider.GetById(adId);
            var adDetailsModel = this.MapAdDetailsToViewModel(adDetails);
            return View("EditAdDetails", adDetailsModel);
        }

        [User]
        [HttpPost]
        public ActionResult SaveAdDetails(AdDetailsViewModel adDetailsModel)
        {
            if (adDetailsModel != null)
            {
                var adDetails = this.MapViewModelToAdDetails(adDetailsModel);
                _adDetailsProvider.Save(adDetails);
                return RedirectToAction("GetAdDetails", new { adId = adDetails.AdId });
            }
            return RedirectToAction("Error", "Error");
        }

        private AdDetails MapViewModelToAdDetails(AdDetailsViewModel adDetailsModel)
        {
            return new AdDetails
            {
                AdId = adDetailsModel.AdId,
                Name = adDetailsModel.Name,
                State = adDetailsModel.State,
                Kind = adDetailsModel.Kind,
                Price = adDetailsModel.Price,
                Description = adDetailsModel.Description,
                Location = new General.Entities.Location { LocationId = adDetailsModel.LocationId },
                User = new User { UserId = adDetailsModel.UserId },
                AddressLine = adDetailsModel.AddressLine,
                CreationDate = adDetailsModel.CreationDate,
                Categories = (IReadOnlyCollection<Category>)adDetailsModel.Categories,
                Images = (IReadOnlyCollection<Image>)adDetailsModel.Images
            };
        }

        private AdDetailsViewModel MapAdDetailsToViewModel(AdDetails adDetails)
        {
            return new AdDetailsViewModel
            {
                AdId = adDetails.AdId,
                Name = adDetails.Name,
                State = adDetails.State,
                Kind = adDetails.Kind,
                Price = adDetails.Price,
                Description = adDetails.Description,
                LocationId = adDetails.Location.LocationId,
                UserId = adDetails.User.UserId,
                AddressLine = adDetails.AddressLine,
                CreationDate = adDetails.CreationDate,
                Categories = adDetails.Categories.ToList(),
                Images = adDetails.Images.ToList()
            };
        }
    }
}