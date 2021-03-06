﻿using Callboard.App.Data.DbContext;
using Callboard.App.Data.Mappers;
using Callboard.App.General.Entities;
using Callboard.App.General.Loggers.Main;
using Callboard.App.General.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Callboard.App.Data.DataContext.Realizations.Db
{
    internal class CategoryDbContext : EntityDbContext<Category>, ICategoryContext
    {
        public CategoryDbContext(IDbContext context, ILoggerWrapper logger) 
            : base(context, logger) { }

        public IResult<Category> GetById(int id)
        {
            string procedureName = "sp_get_category_by_id";
            var mapper = new Mapper<DataSet, Category> { MapItem = this.MapCategory };
            var values = new Dictionary<string, object>
            {
                { "CategoryId", id }
            };
            return base.Get(procedureName, mapper, values);
        }

        public IResult<IReadOnlyCollection<Category>> GetAll()
        {
            string procedureName = "sp_select_category";
            var mapper = new Mapper<DataSet, Category> { MapCollection = this.MapCategoryCollection };
            return base.GetAll(procedureName, mapper);
        }

        public IResult<IReadOnlyCollection<Category>> GetSubcategories(int categoryId)
        {
            var procedureName = "sp_select_subcategory_by_parentid";
            var values = new Dictionary<string, object>
            {
                { "ParentId", categoryId }
            };
            var mapper = new Mapper<DataSet, Category> { MapCollection = this.MapCategoryCollection };
            return base.GetAll(procedureName, mapper, values);
        }

        public IResult<IReadOnlyCollection<Category>> GetMainCategories()
        {
            string procedureName = "sp_select_main_category";
            var mapper = new Mapper<DataSet, Category> { MapCollection = this.MapCategoryCollection };
            return base.GetAll(procedureName, mapper);
        }

        public IResult<Category> Save(Category obj)
        {
            var procedureName = "sp_save_category";
            var mapper = new Mapper<DataSet, Category> { MapValues = this.MapCategoryValues };
            return base.Save(obj, procedureName, mapper);
        }

        public IResult<Category> Delete(int id)
        {
            string procedureName = "sp_delete_category_by_id";
            var values = new Dictionary<string, object>
            {
                { "CategoryId", id }
            };
            return base.Execute(procedureName, values);
        }

        private IDictionary<string, object> MapCategoryValues(Category category)
        {
            return new Dictionary<string, object>
            {
                { "CategoryId", category.CategoryId },
                { "Name", category.Name },
                { "ParentId", category.ParentId }
            };
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

        private Category MapCategory(DataSet dataSet)
        {
            return dataSet.Tables[0].AsEnumerable().Select(category =>
            {
                return MapCategory(category);
            }).First();
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