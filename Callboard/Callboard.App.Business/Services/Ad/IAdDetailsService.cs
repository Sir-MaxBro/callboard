using Callboard.App.General.Entities;

namespace Callboard.App.Business.Services
{
    public interface IAdDetailsService
    {
        AdDetails GetById(int id);

        void Save(AdDetails obj);
    }
}