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
        private SqlDbContext<Ad> _context;
        public AdRepository()
        {
            _context = new SqlDbContext<Ad>();
        }

        public IReadOnlyCollection<Ad> Items
        {
            get
            {
                try
                {
                    _context.Open();
                    _context.Select().Join(new string[] { "Location", "User" });
                    _source = _context.Items;
                }
                finally
                {
                    _context.Close();
                }
                return _source;
            }
        }

        public Ad GetAd(int adID)
        {
            try
            {
                _context.Open();
                _context.Select().Join(new string[] { "Location", "User" });
                _source = _context.Items;
            }
            finally
            {
                _context.Close();
            }
            return _source.First(x => x.Id == adID);
        }

        public IReadOnlyCollection<Ad> GetCategoryAds(int categoryID)
        {
            try
            {
                _context.Open();
                _context.FiltrBy("CategoryId", categoryID);
                _source = _context.Items;
            }
            finally
            {
                _context.Close();
            }
            return _source;
        }
    }
}
