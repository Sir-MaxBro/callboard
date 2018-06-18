using Callboard.App.General.Entities;
using Callboard.App.General.Entities.Data;
using Callboard.App.General.Results;
using System.Collections.Generic;

namespace Callboard.App.Data.Services
{
    public interface IAdService
    {
        IResult<Ad> Delete(int id);

        IResult<IReadOnlyCollection<Ad>> GetAll();

        IResult<IReadOnlyCollection<Ad>> GetAdsByCategoryId(int categoryId);

        IResult<IReadOnlyCollection<Ad>> SearchByName(string name);

        IResult<IReadOnlyCollection<Ad>> Search(SearchConfiguration searchConfiguration);

        IResult<IReadOnlyCollection<Ad>> GetAdsForUser(int userId);
    }
}