using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callboard.App.Common.Entities
{
    public class Area
    {
        public int ID { get; set; }

        public int CountryID { get; set; }

        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
