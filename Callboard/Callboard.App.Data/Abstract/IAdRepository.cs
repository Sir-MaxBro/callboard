using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Data.Abstract
{
    public interface IAdRepository : IEntityRepository<Ad>
    {
        Ad GetAd(int id);

        IReadOnlyCollection<Ad> GetAdsByCategoryId(int categoryId);
    }
}
