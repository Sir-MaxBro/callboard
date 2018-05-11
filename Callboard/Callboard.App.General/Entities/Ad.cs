using System;
using System.Collections.Generic;

namespace Callboard.App.General.Entities
{
    public class Ad
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int LocationID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime CreationDate { get; set; }

        // get from db
        public string Type { get; set; }

        // get from db
        public string State { get; set; }

        public ICollection<Image> Images { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
