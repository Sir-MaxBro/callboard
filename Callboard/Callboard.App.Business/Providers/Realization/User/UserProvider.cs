using Callboard.App.Business.Providers.Main;
using Callboard.App.Data.Repositories.Main;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using System;
using System.Collections.Generic;

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

        public void Delete(int id)
        {
            _checker.CheckId(id);
            _userRepository.Delete(id);
        }

        public IReadOnlyCollection<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            _checker.CheckId(id);
            return _userRepository.GetById(id);
        }

        public void Save(User obj)
        {
            _checker.CheckForNull(obj);
            _userRepository.Save(obj);
        }
    }
}