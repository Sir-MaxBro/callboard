using Callboard.App.General.Entities;

namespace Callboard.App.Data.Repositories
{
    public interface IUserRepository : IEntityRepository<User>
    {
        User GetUserById(int userId);
    }
}
