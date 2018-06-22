using Callboard.App.Data.DataContext;
using Callboard.App.General.Entities;
using Callboard.App.General.Results;
using System;
using System.Collections.Generic;

namespace Callboard.App.Data.Services.Realizations
{
    internal class AreaService : IAreaService
    {
        private IAreaContext _context;
        public AreaService(IAreaContext context)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
        }

        public IResult<Area> Delete(int id)
        {
            return _context.Delete(id);
        }

        public IResult<IReadOnlyCollection<Area>> GetAll()
        {
            return _context.GetAll();
        }

        public IResult<IReadOnlyCollection<Area>> GetAreasByCountryId(int countryId)
        {
            return _context.GetAreasByCountryId(countryId);
        }

        public IResult<Area> GetById(int id)
        {
            return _context.GetById(id);
        }

        public IResult<Area> Save(int countryId, Area obj)
        {
            return _context.Save(countryId, obj);
        }
    }
}