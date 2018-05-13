using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Callboard.App.Web.Models
{
    public class CommercialViewModel
    {
        public IReadOnlyCollection<CommercialService.Commercial> Commercials { get; set; }
    }
}