using Callboard.App.General.Entities;

namespace Callboard.App.Data.Providers.Main
{
    public interface IAdDetailsProvider
    {
        AdDetails GetById(int id);

        void Save(AdDetails adDetails);
    }
}