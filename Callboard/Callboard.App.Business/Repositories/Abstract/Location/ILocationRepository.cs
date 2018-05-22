using Callboard.App.General.Entities;

namespace Callboard.App.Business.Repositories
{
    public interface ILocationRepository : IEntityRepository<Location>
    {
        Location GetLocationByCityId(int cityId);
    }
}
