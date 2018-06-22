using Callboard.App.Data.Repositories;
using Callboard.App.General.Entities.Auth;
using Callboard.App.General.ResultExtensions;
using Callboard.App.General.Results;
using Callboard.App.General.Results.Realizations;
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
            _membershipProvider = membershipProvider ?? throw new NullReferenceException(nameof(membershipProvider));
            _roleRepository = roleRepository ?? throw new NullReferenceException(nameof(roleRepository));
        }

        public IResult<MembershipUser> Login(string login, string password)
        {
            var validResult = this.IsValidUser(login, password);
            if (validResult.IsSuccess())
            {
                var user = GetUser(login);
                this.SendCookies(user);
                return new NoneResult<MembershipUser>();
            }
            return validResult;
        }

        public IResult<MembershipUser> Register(string login, string password)
        {
            var registerResult = new NoneResult<MembershipUser>();

            var userResult = _membershipProvider.CreateUser(login, password);
            if (userResult.IsSuccess())
            {
                var user = userResult.GetSuccessResult();
                this.SendCookies(user);
            }
            else if (userResult.IsFailure())
            {
                return userResult;
            }

            return registerResult;
        }

        public IResult<MembershipUser> Logout()
        {
            FormsAuthentication.SignOut();
            return new NoneResult<MembershipUser>();
        }

        private void SendCookies(MembershipUser user)
        {
            var userData = JsonConvert.SerializeObject(user);
            var ticket = new FormsAuthenticationTicket(VERSION, user.Name, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData);
            var encryptTicket = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        private IResult<MembershipUser> IsValidUser(string login, string password)
        {
            return _membershipProvider.ValidateUser(login, password);
        }

        private MembershipUser GetUser(string login)
        {
            MembershipUser membershipUser = null;
            var userResult = _membershipProvider.GetUserByLogin(login);
            if (userResult.IsSuccess())
            {
                membershipUser = userResult.GetSuccessResult();
            }
            return membershipUser;
        }
    }
}