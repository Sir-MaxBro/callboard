using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Data.Repositories.Main
{
    public interface IAreaRepository : IRepository<Area>
    {
        IReadOnlyCollection<Area> GetAreasByCountryId(int countryId);
    }
}
