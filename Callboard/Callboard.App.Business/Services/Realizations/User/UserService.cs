using Callboard.App.Data.Repositories;
using Callboard.App.General.Entities;
using Callboard.App.General.Exceptions;
using Callboard.App.General.Results;
using System;
using System.Collections.Generic;

namespace Callboard.App.Business.Services.Realizations
{
    internal class UserService : IEntityService<User>
    {
        private IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository ?? throw new NullReferenceException(nameof(userRepository));
        }

        public IResult<User> Delete(int id)
        {
            this.CheckId(id);
            return _userRepository.Delete(id);
        }

        public IResult<IReadOnlyCollection<User>> GetAll()
        {
            return _userRepository.GetAll();
        }

        public IResult<User> GetById(int id)
        {
            this.CheckId(id);
            return _userRepository.GetById(id);
        }

        public IResult<User> Save(User obj)
        {
            obj = obj ?? throw new NullReferenceException(nameof(obj));
            return _userRepository.Save(obj);
        }

        private void CheckId(int id)
        {
            if (id < 1)
            {
                throw new InvalidIdException(nameof(id));
            }
        }
    }
}