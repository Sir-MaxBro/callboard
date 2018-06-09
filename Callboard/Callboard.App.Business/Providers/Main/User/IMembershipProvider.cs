using Callboard.App.General.Entities;

namespace Callboard.App.Business.Providers.Main
{
    public interface IMembershipProvider
    {
        User CreateUser(string login, string password);
    }
}