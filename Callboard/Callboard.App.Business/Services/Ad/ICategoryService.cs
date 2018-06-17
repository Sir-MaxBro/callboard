using Callboard.App.General.Entities;
using Callboard.App.General.Results;
using System.Collections.Generic;

namespace Callboard.App.Business.Services
{
    public interface ICategoryService : IEntityService<Category>
    {
        IResult<IReadOnlyCollection<Category>> GetSubcategories(int categoryId);

        IResult<IReadOnlyCollection<Category>> GetMainCategories();
    }
}