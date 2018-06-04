using Callboard.App.Business.Providers.Main;
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

        public IReadOnlyCollection<Category> GetCategories()
        {
            return _categoryRepository.GetAll();
        }

        public IReadOnlyCollection<Category> GetSubcategories(int categoryId)
        {
            _checker.CheckId(categoryId);
            return _categoryRepository.GetSubcategories(categoryId);
        }
    }
}
