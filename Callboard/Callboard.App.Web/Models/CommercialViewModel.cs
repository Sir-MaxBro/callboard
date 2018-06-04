using Callboard.App.General.Entities.Commercial;
using System.Collections.Generic;

namespace Callboard.App.Web.Models
{
    public class CommercialViewModel
    {
        public IReadOnlyCollection<Commercial> Commercials { get; set; }
    }
}