using Callboard.App.General.Entities;
using Callboard.App.General.Entities.Data;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Results;
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

        public IResult<IReadOnlyCollection<Ad>> GetAds()
        {
            return _adProvider.GetAll();
        }

        public IResult<IReadOnlyCollection<Ad>> GetAdsByCategoryId(int categoryId)
        {
            _checker.CheckId(categoryId);
            return _adProvider.GetAdsByCategoryId(categoryId);
        }

        public IResult<IReadOnlyCollection<Ad>> SearchByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }
            return _adProvider.SearchByName(name);
        }

        public IResult<IReadOnlyCollection<Ad>> Search(SearchConfiguration searchConfiguration)
        {
            _checker.CheckForNull(searchConfiguration);
            return _adProvider.Search(searchConfiguration);
        }

        public IResult<Ad> Delete(int id)
        {
            _checker.CheckId(id);
            return _adProvider.Delete(id);
        }

        public IResult<IReadOnlyCollection<Ad>> GetAdsForUser(int userId)
        {
            _checker.CheckId(userId);
            return _adProvider.GetAdsForUser(userId);
        }
    }
}