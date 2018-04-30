using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callboard.App.Common.Entities
{
    public class Subcategory
    {
        public int ID { get; set; }

        public int CategoryID { get; set; }

        public string Name { get; set; }
    }
}
