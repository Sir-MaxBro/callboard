using Callboard.App.Business.Abstract;
using Callboard.App.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Callboard.App.Business.Concrete
{
    internal class CategoryRepository : ICategoryRepository
    {
        private IReadOnlyCollection<Category> _source = new List<Category>();
        public CategoryRepository()
        {
        }

        public IReadOnlyCollection<Category> Items
        {
            get
            {
                return _source;
            }
        }
    }
}
