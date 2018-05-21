using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Business.Repositories
{
    public interface ICategoryRepository : IEntityRepository<Category>
    {
        IReadOnlyCollection<Category> GetSubcategories(int categoryId);
    }
}
