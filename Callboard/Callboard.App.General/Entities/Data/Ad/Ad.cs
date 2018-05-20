using System;

namespace Callboard.App.General.Entities
{
    public class Ad
    {
        public int AdId { get; set; }

        public int CityId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime CreationDate { get; set; }

        public string Kind { get; set; }

        public string State { get; set; }
    }
}