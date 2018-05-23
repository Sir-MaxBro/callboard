using Callboard.App.General.Entities.Commercial;
using System.Collections.Generic;

namespace Callboard.App.Data.Repositories
{
    public interface ICommercialRepository : IEntityRepository<Commercial>
    {
        IReadOnlyCollection<Commercial> GetCommercials();
    }
}
