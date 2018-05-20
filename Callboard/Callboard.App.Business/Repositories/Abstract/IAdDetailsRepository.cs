using Callboard.App.General.Entities;

namespace Callboard.App.Business.Repositories
{
    public interface IAdDetailsRepository : IEntityRepository<AdDetails>
    {
        AdDetails GetAdDetails(int adId);
    }
}
