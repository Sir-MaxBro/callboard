using Callboard.App.General.Entities.Auth;
using Callboard.App.General.Results;

namespace Callboard.App.Business.Services
{
    public interface IMembershipService
    {
        IResult<MembershipUser> CreateUser(string login, string password);
    }
}