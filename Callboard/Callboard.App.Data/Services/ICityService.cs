using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Data.Services
{
    public interface ICityService
    {
        IReadOnlyCollection<City> GetAll();

        City GetById(int id);

        void Save(int areaId, City obj);

        void Delete(int id);

        IReadOnlyCollection<City> GetCitiesByAreaId(int areaId);
    }
}