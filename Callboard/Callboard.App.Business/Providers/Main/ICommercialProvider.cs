using Callboard.App.General.Entities.Commercial;
using System.Collections.Generic;

namespace Callboard.App.Business.Providers.Main
{
    public interface ICommercialProvider : IEntityProvider<Commercial>
    {
        IReadOnlyCollection<Commercial> GetCommercials();
    }
}
