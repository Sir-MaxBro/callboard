using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Data.Repositories
{
    public interface IAdRepository : IEntityRepository<Ad>
    {
        Ad GetAd(int id);

        IReadOnlyCollection<Ad> GetAdsByCategoryId(int categoryId);
    }
}
