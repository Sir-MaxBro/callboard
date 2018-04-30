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

        public string Type { get; set; }

        public string State { get; set; }

        public byte[] ImageData { get; set; }

        public string ImageMimeType { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
