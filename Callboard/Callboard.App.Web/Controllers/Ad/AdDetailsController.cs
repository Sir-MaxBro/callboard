using Callboard.App.Business.Providers.Main;
using Callboard.App.General.Entities;
using Callboard.App.General.Entities.Auth;
using Callboard.App.General.Helpers.Main;
using Callboard.App.Web.Attributes;
using Callboard.App.Web.Models;
using Newtonsoft.Json;
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
        public ActionResult CreateAdDetails()
        {
            var user = User as UserPrinciple;
            var adDetailsModel = new AdDetailsViewModel
            {
                UserId = user.UserId
            };
            return View("EditAdDetails", adDetailsModel);
        }

        [User]
        public ActionResult EditAdDetails(int adId)
        {
            var adDetails = _adDetailsProvider.GetById(adId);
            var user = User as UserPrinciple;
            if (user.UserId == adDetails.User.UserId)
            {
                var adDetailsModel = this.MapAdDetailsToViewModel(adDetails);
                return View("EditAdDetails", adDetailsModel);
            }
            else
            {
                return RedirectToAction("Error", "Error");
            }
        }

        [User]
        [HttpPost]
        public ActionResult SaveAdDetails(string adDetailsData)
        {
            adDetailsData = adDetailsData ?? string.Empty;
            var adDetailsModel = JsonConvert.DeserializeObject<AdDetailsViewModel>(adDetailsData);
            if (adDetailsModel != null)
            {
                var adDetails = this.MapViewModelToAdDetails(adDetailsModel);
                _adDetailsProvider.Save(adDetails);
                return Json(new { IsSaved = true });
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
                Location = new Location { LocationId = adDetailsModel.Location.LocationId },
                User = new User { UserId = adDetailsModel.UserId },
                AddressLine = adDetailsModel.AddressLine,
                CreationDate = DateTime.Now,
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
                Location = new Location
                {
                    LocationId = adDetails.Location.LocationId,
                    Country = adDetails.Location.Country,
                    Area = adDetails.Location.Area,
                    City = adDetails.Location.City
                },
                UserId = adDetails.User.UserId,
                AddressLine = adDetails.AddressLine,
                Categories = adDetails.Categories.ToArray(),
                Images = adDetails.Images.ToArray()
            };
        }
    }
}