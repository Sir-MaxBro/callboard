using Callboard.App.Business.Abstract;
using Callboard.App.Data.Abstract;
using Callboard.App.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Callboard.App.Business.Concrete
{
    internal class CategoryRepository : ICategoryRepository
    {
        private IReadOnlyCollection<Category> _source = new List<Category>();
        private SqlDbContext<Category> _context;
        public CategoryRepository()
        {
            _context = new SqlDbContext<Category>();
        }

        public IReadOnlyCollection<Category> Items
        {
            get
            {
                try
                {
                    _context.Open();
                    _context.Select().Include("Subcategory");
                    _source = _context.Items;
                }
                finally
                {
                    _context.Close();
                }
                return _source;
            }
        }
    }
}
