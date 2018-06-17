using Callboard.App.Data.Repositories;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Results;
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

        public IResult<User> Delete(int id)
        {
            _checker.CheckId(id);
            return _userRepository.Delete(id);
        }

        public IResult<IReadOnlyCollection<User>> GetAll()
        {
            return _userRepository.GetAll();
        }

        public IResult<User> GetById(int id)
        {
            _checker.CheckId(id);
            return _userRepository.GetById(id);
        }

        public IResult<User> Save(User obj)
        {
            _checker.CheckForNull(obj);
            return _userRepository.Save(obj);
        }
    }
}