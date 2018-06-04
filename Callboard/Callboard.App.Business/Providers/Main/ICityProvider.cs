using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Business.Providers.Main
{
    public interface ICityProvider : IEntityProvider<City>
    {
        IReadOnlyCollection<City> GetCitiesByAreaId(int areaId);
    }
}
