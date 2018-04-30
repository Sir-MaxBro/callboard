using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callboard.App.Common.Entities
{
    public class Membership
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
