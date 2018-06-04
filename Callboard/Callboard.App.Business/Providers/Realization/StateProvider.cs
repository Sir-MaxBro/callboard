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

        public IReadOnlyCollection<State> GetStates()
        {
            return _stateRepository.GetAll();
        }
    }
}