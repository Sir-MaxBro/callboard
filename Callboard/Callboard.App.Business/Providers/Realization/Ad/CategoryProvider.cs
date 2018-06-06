﻿using Callboard.App.Business.Providers.Main;
using Callboard.App.Data.Repositories.Main;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using System;
using System.Collections.Generic;

namespace Callboard.App.Business.Providers.Realization
{
    internal class CategoryProvider : ICategoryProvider
    {
        private IChecker _checker;
        private ICategoryRepository _categoryRepository;
        public CategoryProvider(ICategoryRepository categoryRepository, IChecker checker)
        {
            _checker = checker ?? throw new NullReferenceException(nameof(checker));
            _checker.CheckForNull(categoryRepository);
            _categoryRepository = categoryRepository;
        }

        public void Delete(int id)
        {
            _checker.CheckId(id);
            _categoryRepository.Delete(id);
        }

        public IReadOnlyCollection<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            _checker.CheckId(id);
            return _categoryRepository.GetById(id);
        }

        public IReadOnlyCollection<Category> GetSubcategories(int categoryId)
        {
            _checker.CheckId(categoryId);
            return _categoryRepository.GetSubcategories(categoryId);
        }

        public void Save(Category obj)
        {
            _checker.CheckForNull(obj);
            _categoryRepository.Save(obj);
        }
    }
}