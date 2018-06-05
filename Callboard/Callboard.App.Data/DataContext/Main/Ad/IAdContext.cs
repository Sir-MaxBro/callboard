using Callboard.App.General.Entities;
using Callboard.App.General.Entities.Data.Ad;
using System.Collections.Generic;

namespace Callboard.App.Data.DataContext.Main
{
    public interface IAdContext
    {
        IReadOnlyCollection<Ad> GetAll();

        IReadOnlyCollection<Ad> GetAdsByCategoryId(int categoryId);

        void Delete(int id);

        IReadOnlyCollection<Ad> SearchByName(string name);

        IReadOnlyCollection<Ad> Search(SearchConfiguration searchConfiguration);
    }
}