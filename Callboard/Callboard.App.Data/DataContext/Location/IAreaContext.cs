using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Data.DataContext
{
    public interface IAreaContext
    {
        IReadOnlyCollection<Area> GetAll();

        Area GetById(int id);

        void Save(int countryId, Area obj);

        void Delete(int id);

        IReadOnlyCollection<Area> GetAreasByCountryId(int countryId);
    }
}