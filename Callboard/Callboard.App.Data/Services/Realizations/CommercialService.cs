using Callboard.App.Data.DataContext;
using Callboard.App.General.Entities.Commercial;
using System;
using System.Collections.Generic;

namespace Callboard.App.Data.Services.Realizations
{
    internal class CommercialService : ICommercialService
    {
        private ICommercialContext _context;
        public CommercialService(ICommercialContext context)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
        }

        public IReadOnlyCollection<Commercial> GetCommercials()
        {
            return _context.GetCommercials();
        }
    }
}