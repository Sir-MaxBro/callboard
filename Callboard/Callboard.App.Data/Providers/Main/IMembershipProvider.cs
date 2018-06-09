using Callboard.App.General.Entities;

namespace Callboard.App.Data.Providers.Main
{
    public interface IMembershipProvider
    {
        bool ValidateUser(string login, string password);

        User GetUserByLogin(string login);

        User CreateUser(string login, string password);
    }
}
