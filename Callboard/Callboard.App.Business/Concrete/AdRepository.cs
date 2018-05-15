using Callboard.App.Business.Abstract;
using Callboard.App.Data.Abstract;
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
            SqlDbContext<Ad> context = new SqlDbContext<Ad>("");
            try
            {
                context.Open();
                _source = context.Select();
            }
            finally
            {
                context.Close();
            }
        }

        public IReadOnlyCollection<Ad> Items
        {
            get { return _source; }
            set { throw new NotImplementedException(); }
        }

        public Ad GetAd(int adID)
        {
            return _source.First(x => x.Id == adID);
        }

        public IReadOnlyCollection<Ad> GetCategoryAds(int categoryID)
        {
            return _source.Where(x => x.Categories?.Where(y => y.Id == categoryID).Count() != 0).ToList(); // replace on stored procedure
        }
    }
}
