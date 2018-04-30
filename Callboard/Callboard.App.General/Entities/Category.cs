using System.Collections.Generic;

namespace Callboard.App.General.Entities
{
    public class Category
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<Subcategory> Subcategories { get; set; }
    }
}
