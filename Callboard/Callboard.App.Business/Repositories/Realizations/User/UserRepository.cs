﻿using Callboard.App.Business.DependencyResolution;
using Callboard.App.General.Entities;
using Data = Callboard.App.Data.Repositories;

namespace Callboard.App.Business.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private Data::IUserRepository _repository;
        public UserRepository()
        {
            _repository = DataContainer.GetInstance<Data::IUserRepository>();
        }

        public User GetUserById(int userId)
        {
            return _repository.GetUserById(userId);
        }

        public User GetUserByLogin(string login)
        {
            return _repository.GetUserByLogin(login);
        }
    }
}
