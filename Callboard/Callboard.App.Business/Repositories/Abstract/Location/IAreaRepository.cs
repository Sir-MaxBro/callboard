using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Business.Repositories
{
    public interface IAreaRepository : IEntityRepository<Area>
    {
        IReadOnlyCollection<Area> GetAreasByCountryId(int countryId);
    }
}
