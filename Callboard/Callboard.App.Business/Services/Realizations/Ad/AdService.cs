using Callboard.App.General.Entities;
using Callboard.App.General.Entities.Data;
using Callboard.App.General.Helpers.Main;
using System;
using System.Collections.Generic;
using Data = Callboard.App.Data.Services;

namespace Callboard.App.Business.Services.Realizations
{
    internal class AdService : IAdService
    {
        private Data::IAdService _adProvider;
        private IChecker _checker;
        public AdService(Data::IAdService adProvider, IChecker checker)
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
            _checker.CheckForNull(searchConfiguration);
            return _adProvider.Search(searchConfiguration);
        }

        public void Delete(int id)
        {
            _checker.CheckId(id);
            _adProvider.Delete(id);
        }

        public IReadOnlyCollection<Ad> GetAdsForUser(int userId)
        {
            _checker.CheckId(userId);
            return _adProvider.GetAdsForUser(userId);
        }
    }
}