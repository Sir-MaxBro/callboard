using Callboard.App.Data.Repositories;
using Callboard.App.General.Entities;
using Callboard.App.General.Exceptions;
using Callboard.App.General.Results;
using System;
using System.Collections.Generic;

namespace Callboard.App.Business.Services.Realizations
{
    internal class StateService : IEntityService<State>
    {
        private IRepository<State> _stateRepository;
        public StateService(IRepository<State> stateRepository)
        {
            _stateRepository = stateRepository ?? throw new NullReferenceException(nameof(stateRepository));
        }

        public IResult<State> Delete(int id)
        {
            this.CheckId(id);
            return _stateRepository.Delete(id);
        }

        public IResult<IReadOnlyCollection<State>> GetAll()
        {
            return _stateRepository.GetAll();
        }

        public IResult<State> GetById(int id)
        {
            this.CheckId(id);
            return _stateRepository.GetById(id);
        }

        public IResult<State> Save(State obj)
        {
            obj = obj ?? throw new NullReferenceException(nameof(obj));
            return _stateRepository.Save(obj);
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