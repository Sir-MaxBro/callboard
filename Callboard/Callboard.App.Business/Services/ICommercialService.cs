using Callboard.App.General.Entities.Commercial;
using Callboard.App.General.Results;
using System.Collections.Generic;

namespace Callboard.App.Business.Services
{
    public interface ICommercialService
    {
        IResult<IReadOnlyCollection<Commercial>> GetCommercials();
    }
}