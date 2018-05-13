using System.Collections.Generic;

namespace Callboard.App.General.Entities
{
    public class Area
    {
        public int Id { get; set; }

        //public int CountryId { get; set; }

        public Country Country { get; set; }

        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
