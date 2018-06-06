using Callboard.App.Business.Providers.Main;
using Callboard.App.Data.Repositories.Main;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using System;
using System.Collections.Generic;

namespace Callboard.App.Business.Providers.Realization
{
    internal class StateProvider : IStateProvider
    {
        private IChecker _checker;
        private IStateRepository _stateRepository;
        public StateProvider(IStateRepository stateRepository, IChecker checker)
        {
            _checker = checker ?? throw new NullReferenceException(nameof(checker));
            _checker.CheckForNull(stateRepository);
            _stateRepository = stateRepository;
        }

        public void Delete(int id)
        {
            _checker.CheckId(id);
            _stateRepository.Delete(id);
        }

        public IReadOnlyCollection<State> GetAll()
        {
            return _stateRepository.GetAll();
        }

        public State GetById(int id)
        {
            _checker.CheckId(id);
            return _stateRepository.GetById(id);
        }

        public void Save(State obj)
        {
            _checker.CheckForNull(obj);
            _stateRepository.Save(obj);
        }
    }
}