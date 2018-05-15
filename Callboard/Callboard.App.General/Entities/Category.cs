using System.Collections.Generic;
using Callboard.App.General.Attributes;

namespace Callboard.App.General.Entities
{
    [Table("Category")]
    public class Category
    {
        [Column("CategoryId")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        //public ICollection<Subcategory> Subcategories { get; set; }

        [Include("Subcategory", "CategoryId")]
        public ICollection<Category> Subcategories { get; set; }
    }
}
