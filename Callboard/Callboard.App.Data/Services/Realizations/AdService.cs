using Callboard.App.Data.DataContext;
using Callboard.App.General.Entities;
using Callboard.App.General.Entities.Data;
using System;
using System.Collections.Generic;

namespace Callboard.App.Data.Services.Realizations
{
    internal class AdService : IAdService
    {
        private IAdContext _context;
        public AdService(IAdContext context)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
        }

        public IReadOnlyCollection<Ad> GetAdsByCategoryId(int categoryId)
        {
            return _context.GetAdsByCategoryId(categoryId);
        }

        public IReadOnlyCollection<Ad> GetAll()
        {
            return _context.GetAll();
        }

        public void Delete(int id)
        {
            _context.Delete(id);
        }

        public IReadOnlyCollection<Ad> SearchByName(string name)
        {
            return _context.SearchByName(name);
        }

        public IReadOnlyCollection<Ad> Search(SearchConfiguration searchConfiguration)
        {
            return _context.Search(searchConfiguration);
        }

        public IReadOnlyCollection<Ad> GetAdsForUser(int userId)
        {
            return _context.GetAdsForUser(userId);
        }
    }
}