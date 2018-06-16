using Callboard.App.Data.DataContext;
using Callboard.App.General.Entities;
using System;

namespace Callboard.App.Data.Services.Realizations
{
    internal class MembershipService : IMembershipService
    {
        private IMembershipContext _context;
        public MembershipService(IMembershipContext context)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
        }

        public User GetUserByLogin(string login)
        {
            return _context.GetUserByLogin(login);
        }

        public User CreateUser(string login, string password)
        {
            return _context.CreateUser(login, password);
        }

        public bool ValidateUser(string login, string password)
        {
            return _context.ValidateUser(login, password);
        }
    }
}