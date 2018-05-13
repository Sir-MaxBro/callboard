namespace Callboard.App.General.Entities
{
    public class Subcategory
    {
        public int Id { get; set; }

        //public int CategoryId { get; set; }

        public Category Category { get; set; }

        //public int ParentCategoryId { get; set; }

        public Category ParentCategory { get; set; }
    }
}
