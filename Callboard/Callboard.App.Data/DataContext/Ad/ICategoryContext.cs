using Callboard.App.General.Entities;
using Callboard.App.General.Results;
using System.Collections.Generic;

namespace Callboard.App.Data.DataContext
{
    public interface ICategoryContext : IDataContext<Category>
    {
        IResult<IReadOnlyCollection<Category>> GetSubcategories(int categoryId);

        IResult<IReadOnlyCollection<Category>> GetMainCategories();
    }
}