using Callboard.App.Business.Providers.Main;
using Callboard.App.General.Cache.Main;
using Callboard.App.General.Entities.Commercial;
using Callboard.App.General.Helpers.Main;
using System;
using System.Collections.Generic;
using Data = Callboard.App.Data.Providers.Main;

namespace Callboard.App.Business.Providers.Realization
{
    internal class CommercialProvider : ICommercialProvider
    {
        private IChecker _checker;
        private Data::ICommercialProvider _commercialProvider;
        private ICacheStorage _cacheStorage;
        private const string CACHE_KEY = "commercials";
        public CommercialProvider(ICacheStorage cacheStorage, Data::ICommercialProvider commercialProvider, IChecker checker)
        {
            _checker = checker ?? throw new NullReferenceException(nameof(checker));
            _checker.CheckForNull(cacheStorage);
            _checker.CheckForNull(commercialProvider);
            _commercialProvider = commercialProvider;
            _cacheStorage = cacheStorage;
        }

        public IReadOnlyCollection<Commercial> GetCommercials()
        {
            IReadOnlyCollection<Commercial> commercials = _cacheStorage.Get<IReadOnlyCollection<Commercial>>(CACHE_KEY);
            if (commercials == null)
            {
                commercials = _commercialProvider.GetCommercials();
                _cacheStorage.Add(CACHE_KEY, commercials, milliseconds: 100000);
            }
            return commercials;
        }
    }
}
