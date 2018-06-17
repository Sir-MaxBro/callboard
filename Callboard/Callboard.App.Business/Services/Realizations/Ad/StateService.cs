using Callboard.App.Data.Repositories;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Results;
using System;
using System.Collections.Generic;

namespace Callboard.App.Business.Services.Realizations
{
    internal class StateService : IEntityService<State>
    {
        private IChecker _checker;
        private IRepository<State> _stateRepository;
        public StateService(IRepository<State> stateRepository, IChecker checker)
        {
            _checker = checker ?? throw new NullReferenceException(nameof(checker));
            _checker.CheckForNull(stateRepository);
            _stateRepository = stateRepository;
        }

        public IResult<State> Delete(int id)
        {
            _checker.CheckId(id);
            return _stateRepository.Delete(id);
        }

        public IResult<IReadOnlyCollection<State>> GetAll()
        {
            return _stateRepository.GetAll();
        }

        public IResult<State> GetById(int id)
        {
            _checker.CheckId(id);
            return _stateRepository.GetById(id);
        }

        public IResult<State> Save(State obj)
        {
            _checker.CheckForNull(obj);
            return _stateRepository.Save(obj);
        }
    }
}