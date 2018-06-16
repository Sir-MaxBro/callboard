using Callboard.App.Data.DataContext;
using Callboard.App.General.Entities;
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

        public void Delete(int id)
        {
            _context.Delete(id);
        }

        public IReadOnlyCollection<Country> GetAll()
        {
            return _context.GetAll();
        }

        public Country GetById(int id)
        {
            return _context.GetById(id);
        }

        public void Save(Country obj)
        {
            _context.Save(obj);
        }
    }
}