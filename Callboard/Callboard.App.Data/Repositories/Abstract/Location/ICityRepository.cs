using Callboard.App.General.Entities;

namespace Callboard.App.Data.Repositories
{
    public interface ICityRepository : IEntityRepository<City>
    {
        City GetCity(int cityId);
    }
}
