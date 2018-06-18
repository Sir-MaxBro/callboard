using Callboard.App.General.Entities;
using Callboard.App.General.Results;

namespace Callboard.App.Data.Services
{
    public interface IAdDetailsService
    {
        IResult<AdDetails> GetById(int id);

        IResult<AdDetails> Save(AdDetails adDetails);
    }
}