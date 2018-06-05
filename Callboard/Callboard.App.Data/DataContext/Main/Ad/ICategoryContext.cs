using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Data.DataContext.Main
{
    public interface ICategoryContext : IDataContext<Category>
    {
        IReadOnlyCollection<Category> GetSubcategories(int categoryId);
    }
}