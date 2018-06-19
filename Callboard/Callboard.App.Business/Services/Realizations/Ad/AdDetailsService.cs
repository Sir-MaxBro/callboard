using Callboard.App.General.Entities;
using Callboard.App.General.Exceptions;
using Callboard.App.General.Results;
using System;
using Data = Callboard.App.Data.Services;

namespace Callboard.App.Business.Services.Realizations
{
    internal class AdDetailsService : IAdDetailsService
    {
        private Data::IAdDetailsService _adDetailsProvider;
        public AdDetailsService(Data::IAdDetailsService adDetailsProvider)
        {
            //_checker = checker ?? throw new NullReferenceException(nameof(checker));
            //_checker.CheckForNull(adDetailsProvider);
            _adDetailsProvider = adDetailsProvider ?? throw new NullReferenceException(nameof(adDetailsProvider));
        }

        public IResult<AdDetails> GetById(int id)
        {
            //_checker.CheckId(id);
            if (id < 1)
            {
                throw new InvalidIdException(nameof(id));
            }

            return _adDetailsProvider.GetById(id);
        }

        public IResult<AdDetails> Save(AdDetails obj)
        {
            //_checker.CheckForNull(obj);
            if (obj == null)
            {
                throw new NullReferenceException(nameof(obj));
            }

            return _adDetailsProvider.Save(obj);
        }
    }
}