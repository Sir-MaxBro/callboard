using Callboard.App.General.Entities;

namespace Callboard.App.Business.Repositories
{
    public interface IUserRepository : IEntityRepository<User>
    {
        User GetUserById(int userId);
    }
}
