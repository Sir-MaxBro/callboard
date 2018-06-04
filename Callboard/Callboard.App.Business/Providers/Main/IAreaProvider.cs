using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Business.Providers.Main
{
    public interface IAreaProvider : IEntityProvider<Area>
    {
        IReadOnlyCollection<Area> GetAreasByCountryId(int countryId);
    }
}