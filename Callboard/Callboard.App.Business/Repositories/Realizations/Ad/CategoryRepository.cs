using Callboard.App.Business.DependencyResolution;
using Callboard.App.General.Entities;
using System.Collections.Generic;
using Data = Callboard.App.Data.Repositories;

namespace Callboard.App.Business.Repositories
{
    internal class CategoryRepository : ICategoryRepository
    {
        private Data::ICategoryRepository _repository;
        public CategoryRepository()
        {
            _repository = DataContainer.GetInstance<Data::ICategoryRepository>();
        }

        public IReadOnlyCollection<Category> GetCategories()
        {
            return _repository.GetCategories();
        }

        public IReadOnlyCollection<Category> GetSubcategories(int categoryId)
        {
            return _repository.GetSubcategories(categoryId);
        }
    }
}
