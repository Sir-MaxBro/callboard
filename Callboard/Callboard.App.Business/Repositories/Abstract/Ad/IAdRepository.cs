using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Business.Repositories
{
    public interface IAdRepository : IEntityRepository<Ad>
    {
        IReadOnlyCollection<Ad> GetAdsByCategoryId(int categoryID);

        IReadOnlyCollection<Ad> GetAds();
    }
}
