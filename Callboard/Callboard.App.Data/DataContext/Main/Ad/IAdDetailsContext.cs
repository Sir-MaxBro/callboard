using Callboard.App.General.Entities;

namespace Callboard.App.Data.DataContext.Main
{
    public interface IAdDetailsContext
    {
        AdDetails GetById(int id);

        void Save(AdDetails adDetails);
    }
}