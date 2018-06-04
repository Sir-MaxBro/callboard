using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Data.Repositories.Main
{
    public interface ICityRepository : IRepository<City>
    {
        IReadOnlyCollection<City> GetCitiesByAreaId(int areaId);
    }
}
