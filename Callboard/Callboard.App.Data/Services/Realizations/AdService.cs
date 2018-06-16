using Callboard.App.Data.DataContext;
using Callboard.App.General.Entities;
using Callboard.App.General.Entities.Data;
using Callboard.App.General.Results;
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

        public IResult<IReadOnlyCollection<Ad>> GetAdsByCategoryId(int categoryId)
        {
            return _context.GetAdsByCategoryId(categoryId);
        }

        public IResult<IReadOnlyCollection<Ad>> GetAll()
        {
            return _context.GetAll();
        }

        public IResult<Ad> Delete(int id)
        {
            return _context.Delete(id);
        }

        public IResult<IReadOnlyCollection<Ad>> SearchByName(string name)
        {
            return _context.SearchByName(name);
        }

        public IResult<IReadOnlyCollection<Ad>> Search(SearchConfiguration searchConfiguration)
        {
            return _context.Search(searchConfiguration);
        }

        public IResult<IReadOnlyCollection<Ad>> GetAdsForUser(int userId)
        {
            return _context.GetAdsForUser(userId);
        }
    }
}