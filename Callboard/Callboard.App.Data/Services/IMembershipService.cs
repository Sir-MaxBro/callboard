using Callboard.App.General.Entities.Auth;
using Callboard.App.General.Results;

namespace Callboard.App.Data.Services
{
    public interface IMembershipService
    {
        IResult<MembershipUser> ValidateUser(string login, string password);

        IResult<MembershipUser> GetUserByLogin(string login);

        IResult<MembershipUser> CreateUser(string login, string password);
    }
}