using Callboard.App.General.Entities.Commercial;
using System.Collections.Generic;

namespace Callboard.App.Data.DataContext.Main
{
    public interface ICommercialContext
    {
        IReadOnlyCollection<Commercial> GetCommercials();
    }
}