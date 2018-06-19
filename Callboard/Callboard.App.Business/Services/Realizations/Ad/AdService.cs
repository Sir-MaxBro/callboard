using Callboard.App.General.Entities;
using Callboard.App.General.Entities.Data;
using Callboard.App.General.Exceptions;
using Callboard.App.General.Results;
using System;
using System.Collections.Generic;
using Data = Callboard.App.Data.Services;

namespace Callboard.App.Business.Services.Realizations
{
    internal class AdService : IAdService
    {
        private Data::IAdService _adProvider;
        public AdService(Data::IAdService adProvider)
        {
            _adProvider = adProvider ?? throw new NullReferenceException(nameof(adProvider));
        }

        public IResult<IReadOnlyCollection<Ad>> GetAds()
        {
            return _adProvider.GetAll();
        }

        public IResult<IReadOnlyCollection<Ad>> GetAdsByCategoryId(int categoryId)
        {
            this.CheckId(categoryId);
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
            searchConfiguration = searchConfiguration ?? throw new NullReferenceException(nameof(searchConfiguration));
            return _adProvider.Search(searchConfiguration);
        }

        public IResult<Ad> Delete(int id)
        {
            this.CheckId(id);
            return _adProvider.Delete(id);
        }

        public IResult<IReadOnlyCollection<Ad>> GetAdsForUser(int userId)
        {
            this.CheckId(userId);
            return _adProvider.GetAdsForUser(userId);
        }

        private void CheckId(int id)
        {
            if (id < 1)
            {
                throw new InvalidIdException(nameof(id));
            }
        }
    }
}