using Callboard.App.General.Entities.Auth;
using Callboard.App.General.Results;

namespace Callboard.App.Business.Services
{
    public interface ILogginService
    {
        IResult<MembershipUser> Login(string login, string password);

        IResult<MembershipUser> Logout();

        IResult<MembershipUser> Register(string login, string password);
    }
}