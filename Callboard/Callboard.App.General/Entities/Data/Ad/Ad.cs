using System;
using System.Collections.Generic;

namespace Callboard.App.General.Entities
{
    public class Ad
    {
        public int AdId { get; set; }

        public Location Location { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime CreationDate { get; set; }

        public string Kind { get; set; }

        public string State { get; set; }

        public IReadOnlyCollection<Image> Images { get; set; }

        public IReadOnlyCollection<Category> Categories { get; set; }
    }
}