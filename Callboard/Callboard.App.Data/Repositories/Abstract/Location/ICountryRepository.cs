using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Data.Repositories
{
    public interface ICountryRepository : IEntityRepository<Country>
    {
        IReadOnlyCollection<Country> GetCountries();
    }
}
