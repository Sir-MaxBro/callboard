using Callboard.App.General.Cache.Main;
using Callboard.App.General.Entities.Commercial;
using Callboard.App.General.ResultExtensions;
using Callboard.App.General.Results;
using Callboard.App.General.Results.Realizations;
using System;
using System.Collections.Generic;
using Data = Callboard.App.Data.Services;

namespace Callboard.App.Business.Services.Realizations
{
    internal class CommercialService : ICommercialService
    {
        private Data::ICommercialService _commercialProvider;
        private ICacheStorage _cacheStorage;
        private const string CACHE_KEY = "commercials";
        private const int CACHE_MINUTES = 15;
        public CommercialService(ICacheStorage cacheStorage, Data::ICommercialService commercialProvider)
        {
            _commercialProvider = commercialProvider ?? throw new NullReferenceException(nameof(commercialProvider));
            _cacheStorage = cacheStorage ?? throw new NullReferenceException(nameof(cacheStorage));
        }

        public IResult<IReadOnlyCollection<Commercial>> GetCommercials()
        {
            IReadOnlyCollection<Commercial> commercials = _cacheStorage.Get<IReadOnlyCollection<Commercial>>(CACHE_KEY);

            if (commercials == null)
            {
                var commercialResult = _commercialProvider.GetCommercials();
                if (commercialResult.IsSuccess())
                {
                    commercials = commercialResult.GetSuccessResult();
                    _cacheStorage.Add(CACHE_KEY, commercials, CACHE_MINUTES);
                }
                else
                {
                    return new NoneResult<IReadOnlyCollection<Commercial>>();
                }
            }

            return new SuccessResult<IReadOnlyCollection<Commercial>>(commercials);
        }
    }
}