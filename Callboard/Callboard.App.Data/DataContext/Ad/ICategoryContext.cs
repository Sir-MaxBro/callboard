using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Data.DataContext
{
    public interface ICategoryContext : IDataContext<Category>
    {
        IReadOnlyCollection<Category> GetSubcategories(int categoryId);

        IReadOnlyCollection<Category> GetMainCategories();
    }
}