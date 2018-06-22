using Callboard.App.Data.DataContext;
using Callboard.App.General.Entities;
using Callboard.App.General.Results;
using System;
using System.Collections.Generic;

namespace Callboard.App.Data.Services.Realizations
{
    internal class CityService : ICityService
    {
        private ICityContext _context;
        public CityService(ICityContext context)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
        }

        public IResult<City> Delete(int id)
        {
            return _context.Delete(id);
        }

        public IResult<IReadOnlyCollection<City>> GetAll()
        {
            return _context.GetAll();
        }

        public IResult<City> GetById(int id)
        {
            return _context.GetById(id);
        }

        public IResult<IReadOnlyCollection<City>> GetCitiesByAreaId(int areaId)
        {
            return _context.GetCitiesByAreaId(areaId);
        }

        public IResult<City> Save(int areaId, City obj)
        {
            return _context.Save(areaId, obj);
        }
    }
}