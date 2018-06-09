using Callboard.App.General.Entities;

namespace Callboard.App.Data.DataContext.Main
{
    public interface IMembershipContext
    {
        bool ValidateUser(string login, string password);

        User GetUserByLogin(string login);

        User CreateUser(string login, string password);
    }
}