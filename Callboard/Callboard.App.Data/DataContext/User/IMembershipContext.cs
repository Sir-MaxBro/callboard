using Callboard.App.General.Entities.Auth;
using Callboard.App.General.Results;

namespace Callboard.App.Data.DataContext
{
    public interface IMembershipContext
    {
        IResult<MembershipUser> ValidateUser(string login, string password);

        IResult<MembershipUser> GetUserByLogin(string login);

        IResult<MembershipUser> CreateUser(string login, string password);
    }
}