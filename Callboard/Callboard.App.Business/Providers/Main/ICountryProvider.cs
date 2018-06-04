using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Business.Providers.Main
{
    public interface ICountryProvider : IEntityProvider<Country>
    {
        IReadOnlyCollection<Country> GetCountries();
    }
}
