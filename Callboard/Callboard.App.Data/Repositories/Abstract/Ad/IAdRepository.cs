using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Data.Repositories
{
    public interface IAdRepository : IEntityRepository<Ad>
    { 
        IReadOnlyCollection<Ad> GetAdsByCategoryId(int categoryId);
    }
}
