using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Data.DataContext.Main
{
    public interface IAreaContext : IDataContext<Area>
    {
        IReadOnlyCollection<Area> GetAreasByCountryId(int countryId);
    }
}