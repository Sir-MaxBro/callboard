using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Business.Services
{
    public interface ICategoryService : IEntityService<Category>
    {
        IReadOnlyCollection<Category> GetSubcategories(int categoryId);

        IReadOnlyCollection<Category> GetMainCategories();
    }
}