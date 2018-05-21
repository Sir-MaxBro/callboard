using Callboard.App.General.Entities;

namespace Callboard.App.Data.Repositories
{
    public interface IAdDetailsRepository : IEntityRepository<AdDetails>
    {
        AdDetails GetAdDetails(int adId);
    }
}
