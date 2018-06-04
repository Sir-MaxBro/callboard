using Callboard.App.Business.Providers.Main;
using Callboard.App.Data.Repositories.Main;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using System;

namespace Callboard.App.Business.Providers.Realization
{
    internal class UserProvider : IUserProvider
    {
        private IChecker _checker;
        private IUserRepository _userRepository;
        public UserProvider(IUserRepository userRepository, IChecker checker)
        {
            _checker = checker ?? throw new NullReferenceException(nameof(checker));
            _checker.CheckForNull(userRepository);
            _userRepository = userRepository;
        }

        public User GetUserById(int userId)
        {
            _checker.CheckId(userId);
            return _userRepository.GetById(userId);
        }
    }
}
