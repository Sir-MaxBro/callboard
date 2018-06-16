using Callboard.App.General.Entities;
using Callboard.App.General.Entities.Data;
using System.Collections.Generic;

namespace Callboard.App.Data.Services
{
    public interface IAdService
    {
        void Delete(int id);

        IReadOnlyCollection<Ad> GetAll();

        IReadOnlyCollection<Ad> GetAdsByCategoryId(int categoryId);

        IReadOnlyCollection<Ad> SearchByName(string name);

        IReadOnlyCollection<Ad> Search(SearchConfiguration searchConfiguration);

        IReadOnlyCollection<Ad> GetAdsForUser(int userId);
    }
}