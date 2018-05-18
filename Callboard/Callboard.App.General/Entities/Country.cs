using System.Collections.Generic;

namespace Callboard.App.General.Entities
{
    public class Country
    { 
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Area> Areas { get; set; }
    }
}
