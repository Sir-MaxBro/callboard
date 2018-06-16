using Callboard.App.Data.DataContext;
using Callboard.App.General.Entities;
using System;
using System.Collections.Generic;

namespace Callboard.App.Data.Repositories.Realizations
{
    internal class CategoryRepository : ICategoryRepository
    {
        private ICategoryContext _context;
        public CategoryRepository(ICategoryContext context)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
        }

        public void Delete(int id)
        {
            _context.Delete(id);
        }

        public IReadOnlyCollection<Category> GetAll()
        {
            return _context.GetAll();
        }

        public Category GetById(int id)
        {
            return _context.GetById(id);
        }

        public IReadOnlyCollection<Category> GetSubcategories(int categoryId)
        {
            return _context.GetSubcategories(categoryId);
        }

        public IReadOnlyCollection<Category> GetMainCategories()
        {
            return _context.GetMainCategories();
        }

        public void Save(Category obj)
        {
            _context.Save(obj);
        }
    }
}