using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using System;
using Data = Callboard.App.Data.Services;

namespace Callboard.App.Business.Services.Realizations
{
    internal class MembershipService : IMembershipService
    {
        private Data::IMembershipService _membershipProvider;
        private IChecker _checker;
        public MembershipService(Data::IMembershipService membershipProvider, IChecker checker)
        {
            _checker = checker ?? throw new NullReferenceException(nameof(checker));
            _checker.CheckForNull(membershipProvider);
            _membershipProvider = membershipProvider;
        }

        public User CreateUser(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return null;
            }
            return _membershipProvider.CreateUser(login, password);
        }
    }
}