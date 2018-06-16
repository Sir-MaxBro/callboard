using Callboard.App.General.Entities;

namespace Callboard.App.Data.Services
{
    public interface IMembershipService
    {
        bool ValidateUser(string login, string password);

        User GetUserByLogin(string login);

        User CreateUser(string login, string password);
    }
}