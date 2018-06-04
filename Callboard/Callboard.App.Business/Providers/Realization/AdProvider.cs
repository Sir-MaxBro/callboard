using Callboard.App.Business.Providers.Main;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using System;
using System.Collections.Generic;
using Data = Callboard.App.Data.Providers.Main;

namespace Callboard.App.Business.Providers.Realization
{
    internal class AdProvider : IAdProvider
    {
        private Data::IAdProvider _adRepository;
        private IChecker _checker;
        public AdProvider(Data::IAdProvider adRepository, IChecker checker)
        {
            _checker = checker ?? throw new NullReferenceException(nameof(checker));
            _checker.CheckForNull(adRepository);
            _adRepository = adRepository;
        }

        public IReadOnlyCollection<Ad> GetAds()
        {
            return _adRepository.GetAll();
        }

        public IReadOnlyCollection<Ad> GetAdsByCategoryId(int categoryId)
        {
            _checker.CheckId(categoryId);
            return _adRepository.GetAdsByCategoryId(categoryId);
        }
    }
}
