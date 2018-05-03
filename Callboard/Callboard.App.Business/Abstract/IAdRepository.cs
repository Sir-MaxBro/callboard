using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Business.Abstract
{
    public interface IAdRepository : IEntityRepository<Ad>
    {
        IReadOnlyCollection<Ad> GetCategoryAds(int categoryID);

        Ad GetAd(int adID);
    }
}
