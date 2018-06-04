﻿using Callboard.App.Business.Providers.Main;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using System;
using Data = Callboard.App.Data.Providers.Main;

namespace Callboard.App.Business.Providers.Realization
{
    internal class AdDetailsProvider : IAdDetailsProvider
    {
        private Data::IAdDetailsProvider _adDetailsProvider;
        private IChecker _checker;
        public AdDetailsProvider(Data::IAdDetailsProvider adDetailsProvider, IChecker checker)
        {
            _checker = checker ?? throw new NullReferenceException(nameof(checker));
            _checker.CheckForNull(adDetailsProvider);
            _adDetailsProvider = adDetailsProvider;
        }

        public AdDetails GetAdDetailsById(int adId)
        {
            _checker.CheckId(adId);
            return _adDetailsProvider.GetById(adId);
        }
    }
}
