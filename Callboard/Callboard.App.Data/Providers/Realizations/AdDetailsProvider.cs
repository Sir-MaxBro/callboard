using Callboard.App.Data.DataContext.Main;
using Callboard.App.Data.Providers.Main;
using Callboard.App.General.Entities;
using System;

namespace Callboard.App.Data.Providers.Realizations.Sql
{
    internal class AdDetailsProvider : IAdDetailsProvider
    {
        private IAdDetailsContext _context;
        public AdDetailsProvider(IAdDetailsContext context)
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