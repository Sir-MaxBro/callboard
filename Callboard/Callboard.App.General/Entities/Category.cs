using System.Collections.Generic;

namespace Callboard.App.General.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //public ICollection<Subcategory> Subcategories { get; set; }

        public ICollection<Category> Subcategories { get; set; }
    }
}
