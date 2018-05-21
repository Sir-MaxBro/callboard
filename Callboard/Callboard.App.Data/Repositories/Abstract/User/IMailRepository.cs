using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Data.Repositories
{
    public interface IMailRepository : IEntityRepository<Mail>
    {
        IReadOnlyCollection<Mail> GetMailsByUserId(int userId);
    }
}
