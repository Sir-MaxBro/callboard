using Callboard.App.General.Entities;

namespace Callboard.App.Business.Providers.Main
{
    public interface IAdDetailsProvider : IEntityProvider<AdDetails>
    {
        AdDetails GetAdDetailsById(int adId);

        //void SaveAdDetails(AdDetails adDetails);
    }
}