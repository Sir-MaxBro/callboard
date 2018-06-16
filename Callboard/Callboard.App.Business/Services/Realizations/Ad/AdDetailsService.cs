﻿using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using System;
using Data = Callboard.App.Data.Services;

namespace Callboard.App.Business.Services.Realizations
{
    internal class AdDetailsService : IAdDetailsService
    {
        private Data::IAdDetailsService _adDetailsProvider;
        private IChecker _checker;
        public AdDetailsService(Data::IAdDetailsService adDetailsProvider, IChecker checker)
        {
            _checker = checker ?? throw new NullReferenceException(nameof(checker));
            _checker.CheckForNull(adDetailsProvider);
            _adDetailsProvider = adDetailsProvider;
        }

        public AdDetails GetById(int id)
        {
            _checker.CheckId(id);
            return _adDetailsProvider.GetById(id);
        }

        public void Save(AdDetails obj)
        {
            _checker.CheckForNull(obj);
            _adDetailsProvider.Save(obj);
        }
    }
}