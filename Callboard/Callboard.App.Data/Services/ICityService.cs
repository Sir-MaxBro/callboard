using Callboard.App.General.Entities;
using Callboard.App.General.Results;
using System.Collections.Generic;

namespace Callboard.App.Data.Services
{
    public interface ICityService
    {
        IResult<IReadOnlyCollection<City>> GetAll();

        IResult<City> GetById(int id);

        IResult<City> Save(int areaId, City obj);

        IResult<City> Delete(int id);

        IResult<IReadOnlyCollection<City>> GetCitiesByAreaId(int areaId);
    }
}