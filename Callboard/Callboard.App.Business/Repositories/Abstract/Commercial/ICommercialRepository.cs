using Callboard.App.General.Entities.Commercial;
using System.Collections.Generic;

namespace Callboard.App.Business.Repositories
{
    public interface ICommercialRepository : IEntityRepository<Commercial>
    {
        IReadOnlyCollection<Commercial> GetCommercials();
    }
}
