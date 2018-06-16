using Callboard.App.General.Cache.Main;
using Callboard.App.General.Entities.Commercial;
using Callboard.App.General.Helpers.Main;
using System;
using System.Collections.Generic;
using Data = Callboard.App.Data.Services;

namespace Callboard.App.Business.Services.Realizations
{
    internal class CommercialService : ICommercialService
    {
        private IChecker _checker;
        private Data::ICommercialService _commercialProvider;
        private ICacheStorage _cacheStorage;
        private const string CACHE_KEY = "commercials";
        private const int CACHE_MINUTES = 15;
        public CommercialService(ICacheStorage cacheStorage, Data::ICommercialService commercialProvider, IChecker checker)
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
                _cacheStorage.Add(CACHE_KEY, commercials, CACHE_MINUTES);
            }
            return commercials;
        }
    }
}