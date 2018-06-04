using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Data.Providers.Main
{
    public interface IAdProvider
    {
        IReadOnlyCollection<Ad> GetAll();

        IReadOnlyCollection<Ad> GetAdsByCategoryId(int categoryId);

        void Delete(int id);

        IReadOnlyCollection<Ad> SearchByName(string name);
    }
}
