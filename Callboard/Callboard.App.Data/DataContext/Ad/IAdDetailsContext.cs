using Callboard.App.General.Entities;
using Callboard.App.General.Results;

namespace Callboard.App.Data.DataContext
{
    public interface IAdDetailsContext
    {
        IResult<AdDetails> GetById(int id);

        IResult<AdDetails> Save(AdDetails adDetails);
    }
}