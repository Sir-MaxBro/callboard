using Callboard.App.Business.Providers.Main;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using System;
using Data = Callboard.App.Data.Providers.Main;

namespace Callboard.App.Business.Providers.Realization
{
    internal class MembershipProvider : IMembershipProvider
    {
        private Data::IMembershipProvider _membershipProvider;
        private IChecker _checker;
        public MembershipProvider(Data::IMembershipProvider membershipProvider, IChecker checker)
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