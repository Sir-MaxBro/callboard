using Callboard.App.Data.Infrastructure;
using Callboard.App.General.Entities;
using System;
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

        public IReadOnlyCollection<Category> Items => GetCategories();

        private IReadOnlyCollection<Category> GetCategories()
        {
            IReadOnlyCollection<Category> categories = null;
            using (var context = new DataContext(_connectionString))
            {
                Func<DbDataReader, Category> mapCategory = MapCategory;
                var procedure = base.GetProcedure("selectAll");
                if (procedure != null)
                {
                    categories = context.ExecuteProcedure(procedure.ProcedureName, null, mapCategory);
                }
            }
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
            IReadOnlyCollection<Category> categories = null;
            using (var context = new DataContext(_connectionString))
            {
                Func<DbDataReader, Category> mapCategory = MapCategory;
                var procedure = base.GetProcedure("selectByParentId");
                if (procedure != null)
                {
                    IDictionary<string, object> values = new Dictionary<string, object>
                    {
                        { procedure.Params[0], categoryId }
                    };

                    categories = context.ExecuteProcedure(procedure.ProcedureName, values, mapCategory);
                }
            }
            return categories;
        }
    }
}
