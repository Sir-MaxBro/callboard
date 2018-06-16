using Callboard.App.General.Entities.Commercial;
using System.Collections.Generic;

namespace Callboard.App.Data.Services
{
    public interface ICommercialService
    {
        IReadOnlyCollection<Commercial> GetCommercials();
    }
}