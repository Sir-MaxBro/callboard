using Callboard.App.Data.DataContext;
using Callboard.App.General.Entities.Auth;
using Callboard.App.General.Results;
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

        public IResult<MembershipUser> GetUserByLogin(string login)
        {
            return _context.GetUserByLogin(login);
        }

        public IResult<MembershipUser> CreateUser(string login, string password)
        {
            return _context.CreateUser(login, password);
        }

        public IResult<MembershipUser> ValidateUser(string login, string password)
        {
            return _context.ValidateUser(login, password);
        }
    }
}