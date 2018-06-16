using Callboard.App.General.Entities;

namespace Callboard.App.Data.DataContext
{
    public interface IAdDetailsContext
    {
        AdDetails GetById(int id);

        void Save(AdDetails adDetails);
    }
}