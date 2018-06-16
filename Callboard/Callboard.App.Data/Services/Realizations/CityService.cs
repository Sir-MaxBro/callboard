using Callboard.App.Data.DataContext;
using Callboard.App.General.Entities;
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

        public void Delete(int id)
        {
            _context.Delete(id);
        }

        public IReadOnlyCollection<City> GetAll()
        {
            return _context.GetAll();
        }

        public City GetById(int id)
        {
            return _context.GetById(id);
        }

        public IReadOnlyCollection<City> GetCitiesByAreaId(int areaId)
        {
            return _context.GetCitiesByAreaId(areaId);
        }

        public void Save(int areaId, City obj)
        {
            _context.Save(areaId, obj);
        }
    }
}