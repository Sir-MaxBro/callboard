using Callboard.App.Data.Infrastructure;
using Callboard.App.General.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Callboard.App.Data.Repositories
{
    public class AdRepository : IAdRepository
    {
        private DataContext _context;
        public AdRepository()
        {
            //var table = new DataConfiguration().GetTables();
            var conn = new DataConfiguration().ConnectionString;
            _context = new DataContext(conn);


            var t = GetAds();
        }

        public IReadOnlyCollection<Ad> Items => GetAds();

        private IReadOnlyCollection<Ad> GetAds()
        {
            _context.Open();
            Func<DbDataReader, Ad> mapAd = MapAd;
            var result = _context.ExecuteProcedure("delete table", null, mapAd);
            _context.Close();
            return result;
        }

        private Ad MapAd(DbDataReader dataReader)
        {
            return new Ad
            {
                AdId = (int)dataReader["AdId"],
                Name = (string)dataReader["Name"],
                Price = (decimal)dataReader["Price"]
            };
        }

        public Ad GetAd(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Ad> GetAdsByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}