namespace Callboard.App.Business.Services
{
    public interface ILogginService
    {
        bool Login(string login, string password);

        void Logout();

        void Register(string login, string password);
    }
}