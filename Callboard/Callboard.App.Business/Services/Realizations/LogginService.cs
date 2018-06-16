using Callboard.App.Data.Exceptions;
using Callboard.App.Data.Repositories;
using Callboard.App.General.Entities;
using Callboard.App.General.Entities.Auth;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Security;
using Data = Callboard.App.Data.Services;

namespace Callboard.App.Business.Services.Realizations
{
    internal class LogginService : ILogginService
    {
        private Data::IMembershipService _membershipProvider;
        private IRoleRepository _roleRepository;
        private const int VERSION = 1;
        public LogginService(Data::IMembershipService membershipProvider, IRoleRepository roleRepository)
        {
            _membershipProvider = membershipProvider;
            _roleRepository = roleRepository;
        }

        public bool Login(string login, string password)
        {
            if (IsValidUser(login, password))
            {
                var user = GetUser(login);
                this.SendCookies(user);
                return true;
            }
            return false;
        }

        public void Register(string login, string password)
        {
            User user = null;
            try
            {
                user = _membershipProvider.CreateUser(login, password);
                var membershipUser = this.MapUser(user);
                var roles = _roleRepository.GetRolesForUser(user.UserId);
                membershipUser.Roles = roles;
                this.SendCookies(membershipUser);
            }
            catch (LoginAlreadyExistsException ex)
            {

            }
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        private void SendCookies(MembershipUser user)
        {
            var userData = JsonConvert.SerializeObject(user);
            var ticket = new FormsAuthenticationTicket(VERSION, user.Name, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData);
            var encryptTicket = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
            HttpContext.Current.Response.Cookies.Add(cookie);
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
                membershipUser = this.MapUser(user);
                var roles = _roleRepository.GetRolesForUser(user.UserId);
                membershipUser.Roles = roles;
            }
            return membershipUser;
        }

        private MembershipUser MapUser(User user)
        {
            return new MembershipUser
            {
                UserId = user.UserId,
                Name = user.Name
            };
        }
    }
}