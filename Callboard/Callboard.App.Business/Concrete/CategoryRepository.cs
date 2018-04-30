using Callboard.App.Business.Abstract;
using Callboard.App.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callboard.App.Business.Concrete
{
    internal class CategoryRepository : ICategoryRepository
    {
        private ICollection<Category> _source = new List<Category>();
        public CategoryRepository()
        {
            for (int i = 0; i < 5; i++)
            {
                Category category = new Category();
                category.Name = $"Category {i}";
                _source.Add(category);
            }
        }

        public IReadOnlyCollection<Category> Items
        {
            get => _source.ToList();
            set => throw new NotImplementedException();
        }
    }
}
