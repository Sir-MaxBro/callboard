using Callboard.App.Business.Providers.Main;
using Callboard.App.Data.Repositories.Main;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using System;
using System.Collections.Generic;

namespace Callboard.App.Business.Providers.Realization
{
    internal class KindProvider : IKindProvider
    {
        private IChecker _checker;
        private IKindRepository _kindRepository;
        public KindProvider(IKindRepository kindRepository, IChecker checker)
        {
            _checker = checker ?? throw new NullReferenceException(nameof(checker));
            _checker.CheckForNull(kindRepository);
            _kindRepository = kindRepository;
        }

        public IReadOnlyCollection<Kind> GetKinds()
        {
            return _kindRepository.GetAll();
        }
    }
}
