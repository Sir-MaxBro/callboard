using Callboard.App.Data.Repositories;
using Callboard.App.General.Entities;
using Callboard.App.General.Exceptions;
using Callboard.App.General.Results;
using System;
using System.Collections.Generic;

namespace Callboard.App.Business.Services.Realizations
{
    internal class CountryProvider : IEntityService<Country>
    {
        private IRepository<Country> _countryRepository;
        public CountryProvider(IRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository ?? throw new NullReferenceException(nameof(countryRepository));
        }

        public IResult<Country> Delete(int id)
        {
            this.CheckId(id);
            return _countryRepository.Delete(id);
        }

        public IResult<IReadOnlyCollection<Country>> GetAll()
        {
            return _countryRepository.GetAll();
        }

        public IResult<Country> GetById(int id)
        {
            this.CheckId(id);
            return _countryRepository.GetById(id);
        }

        public IResult<Country> Save(Country obj)
        {
            obj = obj ?? throw new NullReferenceException(nameof(obj));
            return _countryRepository.Save(obj);
        }

        private void CheckId(int id)
        {
            if (id < 1)
            {
                throw new InvalidIdException(nameof(id));
            }
        }
    }
}