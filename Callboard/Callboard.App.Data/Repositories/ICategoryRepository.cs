using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Data.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IReadOnlyCollection<Category> GetSubcategories(int categoryId);

        IReadOnlyCollection<Category> GetMainCategories();
    }
}