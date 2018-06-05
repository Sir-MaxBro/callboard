using Callboard.App.Business.Providers.Main;
using Callboard.App.General.Entities;
using Callboard.App.General.Entities.Data.Ad;
using Callboard.App.General.Helpers.Main;
using System;
using System.Collections.Generic;
using Data = Callboard.App.Data.Providers.Main;

namespace Callboard.App.Business.Providers.Realization
{
    internal class AdProvider : IAdProvider
    {
        private Data::IAdProvider _adProvider;
        private IChecker _checker;
        public AdProvider(Data::IAdProvider adProvider, IChecker checker)
        {
            _checker = checker ?? throw new NullReferenceException(nameof(checker));
            _checker.CheckForNull(adProvider);
            _adProvider = adProvider;
        }

        public IReadOnlyCollection<Ad> GetAds()
        {
            return _adProvider.GetAll();
        }

        public IReadOnlyCollection<Ad> GetAdsByCategoryId(int categoryId)
        {
            _checker.CheckId(categoryId);
            return _adProvider.GetAdsByCategoryId(categoryId);
        }

        public IReadOnlyCollection<Ad> SearchByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }
            return _adProvider.SearchByName(name);
        }

        public IReadOnlyCollection<Ad> Search(SearchConfiguration searchConfiguration)
        {

            return _adProvider.Search(searchConfiguration);
        }
    }
}
