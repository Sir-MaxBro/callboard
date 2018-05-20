using Callboard.App.Data.Entities;
using Callboard.App.Data.Infrastructure;
using Callboard.App.General.Entities;
using Callboard.App.General.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Callboard.App.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private string _connectionString;
        private const string TABLE_NAME = "Category";
        private Table _table;
        public CategoryRepository()
        {
            var configuration = new DataConfiguration();
            _connectionString = configuration.ConnectionString;
            _table = configuration.GetTable(TABLE_NAME);
        }

        public IReadOnlyCollection<Category> Items => GetCategories();

        private IReadOnlyCollection<Category> GetCategories()
        {
            IReadOnlyCollection<Category> categories = null;
            using (var context = new DataContext(_connectionString))
            {
                Func<DbDataReader, Category> mapCategory = MapCategory;
                var procedure = _table.Procedures.FirstOfDefault(item => item.Type == "selectAll");
                if (procedure != null)
                {
                    categories = context.ExecuteProcedure(procedure.ProcedureName, null, mapCategory);
                }
            }
            return categories;
        }

        private Category MapCategory(DbDataReader reader)
        {
            var columns = _table.Columns;
            Func<string, string> getName = propertyName =>
            {
                string name = columns.FirstOfDefault(item => item.MapPropertyName.ToLower() == propertyName)?.Name;
                return name;
            };

            return new Category
            {
                CategoryId = Mapper.MapProperty<int>(reader, "CategoryId", getName),
                Name = Mapper.MapProperty<string>(reader, "Name", getName),
                ParentId = Mapper.MapProperty<int>(reader, "ParentId", getName)
            };
        }

        public IReadOnlyCollection<Category> GetSubcategories(int categoryId)
        {
            IReadOnlyCollection<Category> categories = null;
            using (var context = new DataContext(_connectionString))
            {
                Func<DbDataReader, Category> mapCategory = MapCategory;
                var procedure = _table.Procedures.FirstOfDefault(item => item.Type == "selectByParentId");
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
