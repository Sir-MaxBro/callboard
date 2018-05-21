using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Business.Repositories
{
    public interface IPhoneRepository : IEntityRepository<Phone>
    {
        IReadOnlyCollection<Phone> GetPhonesByUserId(int userId);
    }
}
