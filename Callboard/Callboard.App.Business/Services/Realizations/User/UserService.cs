using Callboard.App.Data.Repositories;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using System;
using System.Collections.Generic;

namespace Callboard.App.Business.Services.Realizations
{
    internal class UserService : IEntityService<User>
    {
        private IChecker _checker;
        private IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository, IChecker checker)
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