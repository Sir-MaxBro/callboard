using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Data.DataContext.Main
{
    public interface ICityContext : IDataContext<City>
    {
        IReadOnlyCollection<City> GetCitiesByAreaId(int areaId);
    }
}