using Callboard.App.General.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Callboard.App.Web.Models
{
    public class NavViewModel
    {
        public IReadOnlyCollection<Category> Categories { get; set; }
    }
}