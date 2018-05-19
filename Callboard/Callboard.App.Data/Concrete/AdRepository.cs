using Callboard.App.Data.Abstract;
using Callboard.App.General.Entities;
using System;
using System.Collections.Generic;

namespace Callboard.App.Data.Concrete
{
    internal class AdRepository : IAdRepository
    {
        public IReadOnlyCollection<Ad> Items => throw new NotImplementedException();

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