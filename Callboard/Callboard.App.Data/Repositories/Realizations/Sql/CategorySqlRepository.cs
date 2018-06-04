using Callboard.App.Data.DataProviders.Main;
using Callboard.App.Data.Mappers;
using Callboard.App.Data.Providers.Main;
using Callboard.App.Data.Repositories.Main;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Loggers.Main;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Callboard.App.Data.Repositories.Realizations.Sql
{
    internal class CategorySqlRepository : SqlProvider<Category>, ICategoryRepository
    {
        public CategorySqlRepository(ISqlDataProvider<Category> sqlProvider, ILoggerWrapper logger, IChecker checker)
            : base(sqlProvider, logger, checker) { }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Category> GetAll()
        {
            var procedureName = "sp_select_category";
            var mapper = new Mapper<DataSet, Category> { MapCollection = MapCategoryCollection };
            var categories = base.GetAll(procedureName, mapper);
            return categories;
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Category> GetSubcategories(int categoryId)
        {
            var procedureName = "sp_select_subcategory_by_parentid";
            var values = new Dictionary<string, object>
            {
                { "ParentId", categoryId }
            };
            var mapper = new Mapper<DataSet, Category> { MapCollection = MapCategoryCollection };
            var subcategories = base.GetAll(procedureName, mapper, values);
            return subcategories;
        }

        public void Save(Category obj)
        {
            throw new NotImplementedException();
        }

        private IReadOnlyCollection<Category> MapCategoryCollection(DataSet dataSet)
        {
            return dataSet.Tables[0].AsEnumerable()
                .Select(categoryRow =>
                {
                    Category category = null;
                    try
                    {
                        category = this.MapCategory(categoryRow);
                    }
                    catch (InvalidCastException ex)
                    {
                        _logger.ErrorFormat($"Cannot cast Category.\n{ ex.Message }");
                    }
                    return category;
                })
                .Where(category => category != null)
                .ToList();
        }

        private Category MapCategory(DataRow row)
        {
            return new Category
            {
                CategoryId = row.Field<int>("CategoryId"),
                Name = row.Field<string>("Name"),
                ParentId = row.Field<int?>("ParentId") ?? default(int)
            };
        }
    }
}