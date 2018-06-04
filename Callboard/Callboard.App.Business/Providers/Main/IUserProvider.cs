using Callboard.App.General.Entities;

namespace Callboard.App.Business.Providers.Main
{
    public interface IUserProvider : IEntityProvider<User>
    {
        User GetUserById(int userId);
    }
}