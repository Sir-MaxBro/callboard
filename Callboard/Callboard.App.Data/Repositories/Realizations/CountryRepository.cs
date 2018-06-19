using Callboard.App.Data.DataContext;
using Callboard.App.General.Entities;
using Callboard.App.General.Results;
using System;
using System.Collections.Generic;

namespace Callboard.App.Data.Repositories.Realizations
{
    internal class CountryRepository : IRepository<Country>
    {
        private IDataContext<Country> _context;
        public CountryRepository(IDataContext<Country> context)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
        }

        public IResult<Country> Delete(int id)
        {
            return _context.Delete(id);
        }

        public IResult<IReadOnlyCollection<Country>> GetAll()
        {
            return _context.GetAll();
        }

        public IResult<Country> GetById(int id)
        {
            return _context.GetById(id);
        }

        public IResult<Country> Save(Country obj)
        {
            return _context.Save(obj);
        }
    }
}