using Callboard.App.General.Entities;

namespace Callboard.App.Data.Services
{
    public interface IAdDetailsService
    {
        AdDetails GetById(int id);

        void Save(AdDetails adDetails);
    }
}