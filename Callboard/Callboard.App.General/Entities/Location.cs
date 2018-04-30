using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callboard.App.Common.Entities
{
    public class Location
    {
        public int ID { get; set; }

        public int CityID { get; set; }

        public string AddressLine { get; set; }
    }
}
