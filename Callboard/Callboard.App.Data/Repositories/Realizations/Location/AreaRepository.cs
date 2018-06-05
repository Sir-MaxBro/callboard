using Callboard.App.Data.DataContext.Main;
using Callboard.App.Data.Repositories.Main;
using Callboard.App.General.Entities;
using System;
using System.Collections.Generic;

namespace Callboard.App.Data.Repositories.Realizations
{
    internal class AreaRepository : IAreaRepository
    {
        private IAreaContext _context;
        public AreaRepository(IAreaContext context)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
        }

        public void Delete(int id)
        {
            _context.Delete(id);
        }

        public IReadOnlyCollection<Area> GetAll()
        {
            return _context.GetAll();
        }

        public IReadOnlyCollection<Area> GetAreasByCountryId(int countryId)
        {
            return _context.GetAreasByCountryId(countryId);
        }

        public Area GetById(int id)
        {
            return _context.GetById(id);
        }

        public void Save(Area obj)
        {
            _context.Save(obj);
        }
    }
}