using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Business.Providers.Main
{
    public interface IAdProvider : IEntityProvider<Ad>
    {
        IReadOnlyCollection<Ad> GetAds();

        IReadOnlyCollection<Ad> GetAdsByCategoryId(int categoryId);

        IReadOnlyCollection<Ad> SearchByName(string name);
    }
}