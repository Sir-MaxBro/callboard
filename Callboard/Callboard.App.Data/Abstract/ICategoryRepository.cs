using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Data.Abstract
{
    public interface ICategoryRepository : IEntityRepository<Category>
    {
        IReadOnlyCollection<Category> GetSubcategories(int categoryId);
    }
}
