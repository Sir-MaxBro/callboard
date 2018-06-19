using Callboard.App.General.Entities.Auth;
using Callboard.App.General.Results;
using System;
using Data = Callboard.App.Data.Services;

namespace Callboard.App.Business.Services.Realizations
{
    internal class MembershipService : IMembershipService
    {
        private Data::IMembershipService _membershipProvider;
        public MembershipService(Data::IMembershipService membershipProvider)
        {
            _membershipProvider = membershipProvider ?? throw new NullReferenceException(nameof(membershipProvider));
        }

        public IResult<MembershipUser> CreateUser(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return null;
            }
            return _membershipProvider.CreateUser(login, password);
        }
    }
}