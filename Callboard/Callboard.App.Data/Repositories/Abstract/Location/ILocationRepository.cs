using Callboard.App.General.Entities;

namespace Callboard.App.Data.Repositories
{
    public interface ILocationRepository : IEntityRepository<Location>
    {
        Location GetLocationByCityId(int cityId);
    }
}
