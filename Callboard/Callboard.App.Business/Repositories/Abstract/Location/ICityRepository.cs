using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Business.Repositories
{
    public interface ICityRepository : IEntityRepository<City>
    {
        IReadOnlyCollection<City> GetCitiesByAreaId(int areaId);
    }
}
