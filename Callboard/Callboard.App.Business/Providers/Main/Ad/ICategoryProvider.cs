using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Business.Providers.Main
{
    public interface ICategoryProvider : IEntityProvider<Category>
    {
        IReadOnlyCollection<Category> GetSubcategories(int categoryId);
    }
}