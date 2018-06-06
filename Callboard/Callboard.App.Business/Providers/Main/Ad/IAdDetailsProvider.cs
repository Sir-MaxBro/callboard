using Callboard.App.General.Entities;

namespace Callboard.App.Business.Providers.Main
{
    public interface IAdDetailsProvider
    {
        AdDetails GetById(int id);

        void Save(AdDetails obj);
    }
}