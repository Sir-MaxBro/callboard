using Callboard.App.Data.DataContext.Main;
using Callboard.App.Data.Providers.Main;
using Callboard.App.General.Entities.Commercial;
using System;
using System.Collections.Generic;

namespace Callboard.App.Data.Providers.Realizations.Service
{
    internal class CommercialProvider : ICommercialProvider
    {
        private ICommercialContext _context;
        public CommercialProvider(ICommercialContext context)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
        }

        public IReadOnlyCollection<Commercial> GetCommercials()
        {
            return _context.GetCommercials();
        }
    }
}