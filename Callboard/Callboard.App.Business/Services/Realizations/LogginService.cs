﻿using Callboard.App.Data.Providers.Main;
using Callboard.App.Data.Repositories.Main;
using Callboard.App.General.Entities.Auth;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Security;

namespace Callboard.App.Business.Services
{
    internal class LogginService : ILogginService
    {
        private IMembershipProvider _membershipProvider;
        private IRoleRepository _roleRepository;
        private const int VERSION = 1;
        public LogginService(IMembershipProvider membershipProvider, IRoleRepository roleRepository)
        {
            _membershipProvider = membershipProvider;
            _roleRepository = roleRepository;
        }

        public bool Login(string login, string password)
        {
            if (IsValidUser(login, password))
            {
                var user = GetUser(login);
                var userData = JsonConvert.SerializeObject(user);
                var ticket = new FormsAuthenticationTicket(VERSION, user.Name, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData);
                var encryptTicket = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
                HttpContext.Current.Response.Cookies.Add(cookie);
                return true;
            }
            return false;
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        private bool IsValidUser(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            return _membershipProvider.ValidateUser(login, password);
        }

        private MembershipUser GetUser(string login)
        {
            MembershipUser membershipUser = null;
            var user = _membershipProvider.GetUserByLogin(login);
            if (user != null)
            {
                membershipUser = new MembershipUser
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    PhotoData = user.PhotoData,
                    PhotoExtension = user.PhotoExtension
                };
                var roles = _roleRepository.GetRolesForUser(user.UserId);
                membershipUser.Roles = roles;
            }
            return membershipUser;
        }
    }
}