﻿using Callboard.App.Business.Providers.Main;
using Callboard.App.General.Entities;
using Callboard.App.General.Entities.Auth;
using Callboard.App.General.Helpers.Main;
using Callboard.App.Web.Attributes;
using Callboard.App.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Callboard.App.Web.Controllers
{
    public class UserController : Controller
    {
        private IChecker _checker;
        private IUserProvider _userProvider;
        public UserController(IUserProvider userProvider, IChecker checker)
        {
            if (checker == null)
            {
                throw new NullReferenceException(nameof(checker));
            }
            _checker = checker;
            _checker.CheckForNull(userProvider);
            _userProvider = userProvider;
        }

        public PartialViewResult GetUser(int userId)
        {
            var user = _userProvider.GetById(userId);
            return PartialView("User", user);
        }

        [User]
        public ActionResult OpenProfile(int userId)
        {
            var userPrinciple = User as UserPrinciple;
            if (userPrinciple.UserId == userId)
            {
                var user = _userProvider.GetById(userId);
                return View("UserProfile", user);
            }
            else
            {
                return RedirectToAction("Error", "Error");
            }
        }

        [User]
        public ActionResult EditUser(int userId, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            var userPrinciple = User as UserPrinciple;
            if (userPrinciple.UserId == userId)
            {
                var user = _userProvider.GetById(userId);
                var userModel = this.MapUserToViewModel(user);
                return PartialView("UserEdit", userModel);
            }
            else
            {
                return RedirectToAction("Error", "Error");
            }
        }

        [User]
        [HttpPost]
        public ActionResult SaveUser(UserViewModel userModel, string returnUrl)
        {
            if (userModel != null)
            {
                var user = this.MapViewModelToUser(userModel);
                _userProvider.Save(user);
            }
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("GetAdList", "Ad");
        }

        [Admin]
        public ActionResult GetAllUsers()
        {
            var users = _userProvider.GetAll();
            return View("UserList", users);
        }

        [Admin]
        [HttpPost]
        public ActionResult DeleteUserById(int userId)
        {
            _userProvider.Delete(userId);
            return RedirectToAction("GetAllUsers");
        }

        private UserViewModel MapUserToViewModel(User user)
        {
            return new UserViewModel
            {
                UserId = user.UserId,
                Name = user.Name,
                PhotoData = user.PhotoData,
                PhotoExtension = user.PhotoExtension,
                Phones = user.Phones.ToList(),
                Mails = user.Mails.ToList()
            };
        }

        private User MapViewModelToUser(UserViewModel userModel)
        {
            return new User
            {
                UserId = userModel.UserId,
                Name = userModel.Name,
                PhotoData = userModel.PhotoData,
                PhotoExtension = userModel.PhotoExtension,
                Mails = (IReadOnlyCollection<Mail>)userModel.Mails,
                Phones = (IReadOnlyCollection<Phone>)userModel.Phones
            };
        }
    }
}