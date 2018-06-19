using Callboard.App.Data.DataContext;
using Callboard.App.General.Entities;
using Callboard.App.General.Results;
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

        public IResult<Category> Delete(int id)
        {
            return _context.Delete(id);
        }

        public IResult<IReadOnlyCollection<Category>> GetAll()
        {
            return _context.GetAll();
        }

        public IResult<Category> GetById(int id)
        {
            return _context.GetById(id);
        }

        public IResult<IReadOnlyCollection<Category>> GetSubcategories(int categoryId)
        {
            return _context.GetSubcategories(categoryId);
        }

        public IResult<IReadOnlyCollection<Category>> GetMainCategories()
        {
            return _context.GetMainCategories();
        }

        public IResult<Category> Save(Category obj)
        {
            return _context.Save(obj);
        }
    }
}