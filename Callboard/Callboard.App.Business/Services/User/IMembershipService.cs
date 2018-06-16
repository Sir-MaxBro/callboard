using Callboard.App.General.Entities;

namespace Callboard.App.Business.Services
{
    public interface IMembershipService
    {
        User CreateUser(string login, string password);
    }
}