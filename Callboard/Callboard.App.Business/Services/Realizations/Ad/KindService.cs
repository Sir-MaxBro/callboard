using Callboard.App.Data.Repositories;
using Callboard.App.General.Entities;
using Callboard.App.General.Exceptions;
using Callboard.App.General.Results;
using System;
using System.Collections.Generic;

namespace Callboard.App.Business.Services.Realizations
{
    internal class KindService : IEntityService<Kind>
    {
        private IRepository<Kind> _kindRepository;
        public KindService(IRepository<Kind> kindRepository)
        {
            _kindRepository = kindRepository ?? throw new NullReferenceException(nameof(kindRepository));
        }

        public IResult<Kind> Delete(int id)
        {
            this.CheckId(id);
            return _kindRepository.Delete(id);
        }

        public IResult<IReadOnlyCollection<Kind>> GetAll()
        {
            return _kindRepository.GetAll();
        }

        public IResult<Kind> GetById(int id)
        {
            this.CheckId(id);
            return _kindRepository.GetById(id);
        }

        public IResult<Kind> Save(Kind obj)
        {
            obj = obj ?? throw new NullReferenceException(nameof(obj));
            return _kindRepository.Save(obj);
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