using System.Collections.Generic;

namespace Callboard.App.General.Entities
{
    public class Area
    {
        public int ID { get; set; }

        public int CountryID { get; set; }

        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
