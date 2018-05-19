using Callboard.App.Business.Abstract;
using Callboard.App.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Callboard.App.Business.Concrete
{
    internal class AdRepository : IAdRepository
    {
        private IReadOnlyCollection<Ad> _source;
        public AdRepository()
        {

        }

        public IReadOnlyCollection<Ad> Items
        {
            get
            {
                return _source;
            }
        }

        public Ad GetAd(int adID)
        {
            return null;
        }

        public IReadOnlyCollection<Ad> GetCategoryAds(int categoryID)
        {
            return null;
        }
    }
}
