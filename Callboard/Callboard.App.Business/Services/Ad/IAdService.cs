using Callboard.App.General.Entities;
using Callboard.App.General.Entities.Data;
using System.Collections.Generic;

namespace Callboard.App.Business.Services
{
    public interface IAdService
    {
        IReadOnlyCollection<Ad> GetAds();

        IReadOnlyCollection<Ad> GetAdsByCategoryId(int categoryId);

        IReadOnlyCollection<Ad> SearchByName(string name);

        IReadOnlyCollection<Ad> Search(SearchConfiguration searchConfiguration);

        void Delete(int id);

        IReadOnlyCollection<Ad> GetAdsForUser(int userId);
    }
}