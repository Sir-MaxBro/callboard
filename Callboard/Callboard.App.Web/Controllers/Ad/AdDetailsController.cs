using Callboard.App.Business.Services;
using Callboard.App.General.Entities;
using Callboard.App.General.Entities.Auth;
using Callboard.App.General.ResultExtensions;
using Callboard.App.Web.Attributes;
using Callboard.App.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class AdDetailsController : Controller
    {
        private IAdDetailsService _adDetailsProvider;
        public AdDetailsController(IAdDetailsService adDetailsProvider)
        {
            if (adDetailsProvider == null)
            {
                throw new NullReferenceException(nameof(adDetailsProvider));
            }
            _adDetailsProvider = adDetailsProvider;
        }

        public ActionResult GetAdDetails(int adId)
        {
            var adDetailsResult = _adDetailsProvider.GetById(adId);
            if (adDetailsResult.IsSuccess())
            {
                AdDetails model = adDetailsResult.GetSuccessResult();
                return View("AdDetails", model);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
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
            var adDetailsResult = _adDetailsProvider.GetById(adId);
            if (adDetailsResult.IsSuccess())
            {
                var user = User as UserPrinciple;
                var adDetails = adDetailsResult.GetSuccessResult();
                if (user.UserId == adDetails.User.UserId)
                {
                    var adDetailsModel = this.MapAdDetailsToViewModel(adDetails);
                    return View("EditAdDetails", adDetailsModel);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        [User]
        [AjaxOnly]
        [HttpPost]
        public ActionResult SaveAdDetails(string adDetailsData)
        {
            adDetailsData = adDetailsData ?? string.Empty;
            var adDetailsModel = JsonConvert.DeserializeObject<AdDetailsViewModel>(adDetailsData);
            if (adDetailsModel != null)
            {
                var adDetails = this.MapViewModelToAdDetails(adDetailsModel);
                var adDetailsResult = _adDetailsProvider.Save(adDetails);
                if (adDetailsResult.IsNone())
                {
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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