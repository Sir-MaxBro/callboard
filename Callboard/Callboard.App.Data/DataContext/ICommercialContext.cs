using Callboard.App.General.Entities.Commercial;
using Callboard.App.General.Results;
using System.Collections.Generic;

namespace Callboard.App.Data.DataContext
{
    public interface ICommercialContext
    {
        IResult<IReadOnlyCollection<Commercial>> GetCommercials();
    }
}