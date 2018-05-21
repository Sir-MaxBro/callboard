using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Business.Repositories
{
    public interface IMailRepository : IEntityRepository<Mail>
    {
        IReadOnlyCollection<Mail> GetMailsByUserId(int userId);
    }
}
