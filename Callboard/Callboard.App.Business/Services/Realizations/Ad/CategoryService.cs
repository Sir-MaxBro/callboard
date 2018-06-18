using Callboard.App.Data.Repositories;
using Callboard.App.General.Entities;
using Callboard.App.General.Exceptions;
using Callboard.App.General.Results;
using System;
using System.Collections.Generic;

namespace Callboard.App.Business.Services.Realizations
{
    internal class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new NullReferenceException(nameof(categoryRepository));
        }

        public IResult<Category> Delete(int id)
        {
            this.CheckId(id);
            return _categoryRepository.Delete(id);
        }

        public IResult<IReadOnlyCollection<Category>> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public IResult<Category> GetById(int id)
        {
            this.CheckId(id);
            return _categoryRepository.GetById(id);
        }

        public IResult<IReadOnlyCollection<Category>> GetSubcategories(int categoryId)
        {
            this.CheckId(categoryId);
            return _categoryRepository.GetSubcategories(categoryId);
        }

        public IResult<IReadOnlyCollection<Category>> GetMainCategories()
        {
            return _categoryRepository.GetMainCategories();
        }

        public IResult<Category> Save(Category obj)
        {
            obj = obj ?? throw new NullReferenceException(nameof(obj));
            return _categoryRepository.Save(obj);
        }

        private void CheckId(int id)
        {
            if (id < 1)
            {
                throw new InvalidIdException(nameof(id));
            }
        }
    }
}