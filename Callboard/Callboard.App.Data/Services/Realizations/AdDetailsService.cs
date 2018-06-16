using Callboard.App.Data.DataContext;
using Callboard.App.General.Entities;
using System;

namespace Callboard.App.Data.Services.Realizations
{
    internal class AdDetailsService : IAdDetailsService
    {
        private IAdDetailsContext _context;
        public AdDetailsService(IAdDetailsContext context)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
        }

        public AdDetails GetById(int id)
        {
            return _context.GetById(id);
        }

        public void Save(AdDetails adDetails)
        {
            _context.Save(adDetails);
        }
    }
}