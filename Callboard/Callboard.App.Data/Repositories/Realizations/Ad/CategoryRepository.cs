using Callboard.App.Data.Infrastructure;
using Callboard.App.General.Entities;
using System.Collections.Generic;
using System.Data.Common;

namespace Callboard.App.Data.Repositories
{
    internal class CategoryRepository : EntityRepository, ICategoryRepository
    {
        private const string TABLE_NAME = "Category";
        public CategoryRepository()
            : base() { }

        protected override string TableName => TABLE_NAME;

        public IReadOnlyCollection<Category> GetCategories()
        {
            IReadOnlyCollection<Category> categories = base.GetEntities<Category>("selectAll", MapCategory);
            return categories;
        }

        private Category MapCategory(DbDataReader reader)
        {
            return new Category
            {
                CategoryId = Mapper.MapProperty<int>(reader, "CategoryId", base.GetName),
                Name = Mapper.MapProperty<string>(reader, "Name", base.GetName),
                ParentId = Mapper.MapProperty<int>(reader, "ParentId", base.GetName)
            };
        }

        public IReadOnlyCollection<Category> GetSubcategories(int categoryId)
        {
            IReadOnlyCollection<Category> categories = base.GetEntities<Category>("selectByParentId", MapCategory, categoryId);
            return categories;
        }
    }
}
