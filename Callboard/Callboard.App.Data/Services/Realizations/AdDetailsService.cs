using Callboard.App.Data.DataContext;
using Callboard.App.General.Entities;
using Callboard.App.General.Results;
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

        public IResult<AdDetails> GetById(int id)
        {
            return _context.GetById(id);
        }

        public IResult<AdDetails> Save(AdDetails adDetails)
        {
            return _context.Save(adDetails);
        }
    }
}