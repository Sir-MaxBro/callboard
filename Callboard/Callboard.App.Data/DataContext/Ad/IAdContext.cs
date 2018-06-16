using Callboard.App.General.Entities;
using Callboard.App.General.Entities.Data;
using System.Collections.Generic;

namespace Callboard.App.Data.DataContext
{
    public interface IAdContext
    {
        IReadOnlyCollection<Ad> GetAll();

        IReadOnlyCollection<Ad> GetAdsByCategoryId(int categoryId);

        void Delete(int id);

        IReadOnlyCollection<Ad> SearchByName(string name);

        IReadOnlyCollection<Ad> Search(SearchConfiguration searchConfiguration);

        IReadOnlyCollection<Ad> GetAdsForUser(int userId);
    }
}