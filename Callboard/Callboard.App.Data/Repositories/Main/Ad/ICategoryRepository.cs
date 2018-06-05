using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Data.Repositories.Main
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IReadOnlyCollection<Category> GetSubcategories(int categoryId);
    }
}
